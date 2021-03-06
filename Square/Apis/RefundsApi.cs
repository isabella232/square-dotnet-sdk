using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;
using Square.Authentication;

namespace Square.Apis
{
    internal class RefundsApi : BaseApi, IRefundsApi
    {
        internal RefundsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Retrieves a list of refunds for the account making the request.
        /// The maximum results per page is 100.
        /// </summary>
        /// <param name="beginTime">Optional parameter: Timestamp for the beginning of the requested reporting period, in RFC 3339 format.  Default: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: Timestamp for the end of the requested reporting period, in RFC 3339 format.  Default: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed. - `ASC` - oldest to newest - `DESC` - newest to oldest (default).</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for all locations associated with the merchant.</param>
        /// <param name="status">Optional parameter: If provided, only refunds with the given status are returned. For a list of refund status values, see [PaymentRefund](#type-paymentrefund).  Default: If omitted refunds are returned regardless of status.</param>
        /// <param name="sourceType">Optional parameter: If provided, only refunds with the given source type are returned. - `CARD` - List refunds only for payments where card was specified as payment source.  Default: If omitted refunds are returned regardless of source type.</param>
        /// <param name="limit">Optional parameter: Maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page.  If the supplied value is greater than 100, at most 100 results will be returned.  Default: `100`</param>
        /// <return>Returns the Models.ListPaymentRefundsResponse response from the API call</return>
        public Models.ListPaymentRefundsResponse ListPaymentRefunds(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                string status = null,
                string sourceType = null,
                int? limit = null)
        {
            Task<Models.ListPaymentRefundsResponse> t = ListPaymentRefundsAsync(beginTime, endTime, sortOrder, cursor, locationId, status, sourceType, limit);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a list of refunds for the account making the request.
        /// The maximum results per page is 100.
        /// </summary>
        /// <param name="beginTime">Optional parameter: Timestamp for the beginning of the requested reporting period, in RFC 3339 format.  Default: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: Timestamp for the end of the requested reporting period, in RFC 3339 format.  Default: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed. - `ASC` - oldest to newest - `DESC` - newest to oldest (default).</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.</param>
        /// <param name="locationId">Optional parameter: Limit results to the location supplied. By default, results are returned for all locations associated with the merchant.</param>
        /// <param name="status">Optional parameter: If provided, only refunds with the given status are returned. For a list of refund status values, see [PaymentRefund](#type-paymentrefund).  Default: If omitted refunds are returned regardless of status.</param>
        /// <param name="sourceType">Optional parameter: If provided, only refunds with the given source type are returned. - `CARD` - List refunds only for payments where card was specified as payment source.  Default: If omitted refunds are returned regardless of source type.</param>
        /// <param name="limit">Optional parameter: Maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page.  If the supplied value is greater than 100, at most 100 results will be returned.  Default: `100`</param>
        /// <return>Returns the Models.ListPaymentRefundsResponse response from the API call</return>
        public async Task<Models.ListPaymentRefundsResponse> ListPaymentRefundsAsync(
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null,
                string locationId = null,
                string status = null,
                string sourceType = null,
                int? limit = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/refunds");

            //prepare specfied query parameters
            var _queryParameters = new Dictionary<string, object>()
            {
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "sort_order", sortOrder },
                { "cursor", cursor },
                { "location_id", locationId },
                { "status", status },
                { "source_type", sourceType },
                { "limit", limit }
            };

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", config.SquareVersion }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryBuilder.ToString(), _headers, queryParameters: _queryParameters);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["global"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListPaymentRefundsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Refunds a payment. You can refund the entire payment amount or a 
        /// portion of it.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RefundPaymentResponse response from the API call</return>
        public Models.RefundPaymentResponse RefundPayment(Models.RefundPaymentRequest body)
        {
            Task<Models.RefundPaymentResponse> t = RefundPaymentAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Refunds a payment. You can refund the entire payment amount or a 
        /// portion of it.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.RefundPaymentResponse response from the API call</return>
        public async Task<Models.RefundPaymentResponse> RefundPaymentAsync(Models.RefundPaymentRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/refunds");

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryBuilder.ToString(), _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["global"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.RefundPaymentResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Retrieves a specific refund using the `refund_id`.
        /// </summary>
        /// <param name="refundId">Required parameter: Unique ID for the desired `PaymentRefund`.</param>
        /// <return>Returns the Models.GetPaymentRefundResponse response from the API call</return>
        public Models.GetPaymentRefundResponse GetPaymentRefund(string refundId)
        {
            Task<Models.GetPaymentRefundResponse> t = GetPaymentRefundAsync(refundId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a specific refund using the `refund_id`.
        /// </summary>
        /// <param name="refundId">Required parameter: Unique ID for the desired `PaymentRefund`.</param>
        /// <return>Returns the Models.GetPaymentRefundResponse response from the API call</return>
        public async Task<Models.GetPaymentRefundResponse> GetPaymentRefundAsync(string refundId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/refunds/{refund_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "refund_id", refundId }
            });

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            {
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", config.SquareVersion }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryBuilder.ToString(), _headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["global"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.GetPaymentRefundResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}