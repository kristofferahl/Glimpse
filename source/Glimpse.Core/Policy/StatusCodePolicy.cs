﻿using System;
using System.Collections.Generic;
using Glimpse.Core.Configuration;
using Glimpse.Core.Extensibility;
using Glimpse.Core;

namespace Glimpse.Core.Policy
{
    public class StatusCodePolicy:IRuntimePolicy, IConfigurable
    {
        public IList<int> StatusCodeWhitelist { get; set; }

        public StatusCodePolicy()
        {
            StatusCodeWhitelist = new List<int>();
        }

        public StatusCodePolicy(IList<int> statusCodeWhitelist)
        {
            if (statusCodeWhitelist == null) throw new ArgumentNullException("statusCodeWhitelist");

            StatusCodeWhitelist = statusCodeWhitelist;
        }

        public RuntimePolicy Execute(IRuntimePolicyContext policyContext)
        {
            try
            {
                var statusCode = policyContext.RequestMetadata.ResponseStatusCode;
                return StatusCodeWhitelist.Contains(statusCode) ? RuntimePolicy.On : RuntimePolicy.Off;
            }
            catch (Exception exception)
            {
                policyContext.Logger.Warn(Resources.ExecutePolicyWarning, exception, GetType());
                return RuntimePolicy.Off;
            }
        }

        public RuntimeEvent ExecuteOn
        {
            get { return RuntimeEvent.EndRequest; }
        }

        public void Configure(GlimpseSection section)
        {
            StatusCodeWhitelist = new List<int>();

            foreach (StatusCodeElement item in section.RuntimePolicies.StatusCodes)
            {
                StatusCodeWhitelist.Add(item.StatusCode);
            }
        }
    }
}