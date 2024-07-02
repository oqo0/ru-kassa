using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ru.Kassa.Helpers;
using Ru.Kassa.Models.Exceptions;
using Ru.Kassa.Models.Requests;
using Ru.Kassa.Models.Requests.Merchant;
using Ru.Kassa.Models.Requests.User;
using Ru.Kassa.Models.Response;

namespace Ru.Kassa
{
    /// <summary>
    /// Клиент для работы с RuKassa API
    /// </summary>
    public class RuKassaClient
    {
        private const string ApiUrl = "https://lk.rukassa.pro/api/v1/";
        
        private readonly int _shopId;
        private readonly string _token;
        private readonly string _userEmail;
        private readonly string _userPassword;
        private readonly HttpClient _httpClient;

        public RuKassaClient(int merchantId, string token)
        {
            _shopId = merchantId;
            _token = token;
            
            _httpClient = new HttpClient();
        }

        public RuKassaClient(int merchantId, string token, string userEmail, string userPassword)
        {
            _shopId = merchantId;
            _token = token;
            _userEmail = userEmail;
            _userPassword = userPassword;
            
            _httpClient = new HttpClient();
        }
        
        /// <summary>
        /// Создаёт платёж
        /// </summary>
        /// <param name="request">Запрос с данными для создания платежа</param>
        /// <returns></returns>
        public async Task<PaymentResponse> CreatePaymentAsync(PaymentMerchantRequest request)
            => await SendMerchantRequest<PaymentResponse>(request, "create");

        /// <summary>
        /// Возвращает информацию об уже существующем платеже
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ExistingPaymentResponse> GetPaymentAsync(ExistingPaymentMerchantRequest request)
            => await SendMerchantRequest<ExistingPaymentResponse>(request, "getPayInfo");

        /// <summary>
        /// Возвращает информацию в выводе средств
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<WithdrawalResponse> GetWithdrawalAsync(WithdrawalMerchantRequest request)
            => await SendMerchantRequest<WithdrawalResponse>(request, "getWithdrawInfo");

        /// <summary>
        /// Возвращает баланс пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<UserBalanceResponse> GetBalanceAsync()
            => await SendUserRequest<UserBalanceResponse>(new BalanceUserRequest(), "getBalance");
        
        /// <summary>
        /// Запрашивает вывод средств
        /// </summary>
        /// <returns></returns>
        public async Task<WithdrawalResponse> CreateWithdrawalAsync(WithdrawalUserRequest request)
            => await SendUserRequest<WithdrawalResponse>(request, "createWithdraw");
        
        private async Task<T> SendMerchantRequest<T>(IMerchantRequest request, string apiUrlPath)
        {
            AuthorizeMerchant(request);
            
            return await SendRequest<T>(request, apiUrlPath);
        }
        
        private async Task<T> SendUserRequest<T>(IUserRequest request, string apiUrlPath)
        {
            AuthorizeUser(request);
            
            return await SendRequest<T>(request, apiUrlPath);
        }
        
        private async Task<T> SendRequest<T>(IRequest request, string apiUrlPath)
        {
            var responseString = await Queue(request, apiUrlPath);
            var responseObject = JsonConvert.DeserializeObject<T>(responseString);
            
            HandleErrors(responseObject as IResponse);

            return responseObject;
        }

        private async Task<string> Queue(IRequest request, string apiUrlPath)
        {
            var formData = new FormData(request);

            var message = new StringContent(formData.AsString);

            string apiEndpoint = ApiUrl + apiUrlPath;
            
            message.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            
            var httpResponseMessage = await _httpClient.PostAsync(apiEndpoint, message);
            string responseAsString = await httpResponseMessage.Content.ReadAsStringAsync();
            
            return responseAsString;
        }

        private void AuthorizeMerchant(IMerchantRequest paymentRequest)
        {
            paymentRequest.ShopId = _shopId;
            paymentRequest.Token = _token;
        }
        
        private void AuthorizeUser(IUserRequest paymentRequest)
        {
            paymentRequest.Email = _userEmail;
            paymentRequest.Password = _userPassword;
        }
        
        private void HandleErrors(IResponse response)
        {
            if (response is null)
                throw new ArgumentException();
            
            bool noErrorFound = string.IsNullOrEmpty(response.Error);
            if (noErrorFound)
                return;
            
            switch (response.Error)
            {
                case "100":
                    throw new ValueWasNotGivenException(response);
                case "200":
                    throw new ShopOrPaymentNotFoundException(response);
                case "300":
                    throw new MerchantIsNotVerifiedException(response);
                case "400":
                    throw new KassaException(response);
                default:
                    throw new KassaException(response);
            }
        }
    }
}