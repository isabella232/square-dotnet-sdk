using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CreateRefundResponse 
    {
        public CreateRefundResponse(IList<Models.Error> errors = null,
            Models.Refund refund = null)
        {
            Errors = errors;
            Refund = refund;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a refund processed for a Square transaction.
        /// </summary>
        [JsonProperty("refund", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Refund Refund { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Refund(Refund);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Refund refund;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Refund(Models.Refund refund)
            {
                this.refund = refund;
                return this;
            }

            public CreateRefundResponse Build()
            {
                return new CreateRefundResponse(errors,
                    refund);
            }
        }
    }
}