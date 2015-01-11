using System;
using System.Net;

using Microsoft.SharePoint.Client;

namespace SharePointAweSOM
{
    public class Sites : IDisposable
    {
        private readonly ClientContext clientContext;

        public Sites(string siteUrl, ICredentials credentials)
        {
            this.clientContext = new ClientContext(siteUrl) { Credentials = credentials };
        }

        public Site GetSite()
        {
            var site = this.clientContext.Site;
            this.clientContext.Load(site);
            this.clientContext.ExecuteQuery();
            return site;
        }

        public void Dispose()
        {
            if (this.clientContext != null)
            {
                this.clientContext.Dispose();
            }
        }
    }
}
