// ***********************************************************************
// Assembly         : RS.Firstrac.DataObjects
// Author           : ricardo.fraire
// Created          : 04-21-2023
//
// Last Modified By : ricardo.fraire
// Last Modified On : 04-21-2023
// ***********************************************************************
// <copyright file="FirstracApiHelper.cs" company="RS.Firstrac.DataObjects">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RS.Common.Data.API6.Helpers;

namespace RS.Firstrac.DataObjects.ApiIHelper
{
    /// <summary>
    /// Class FirstracApiHelper.
    /// Implements the <see cref="APIHelper" />
    /// Implements the <see cref="RS.Firstrac.DataObjects.ApiIHelper.IFirstracApiHelper" />
    /// </summary>
    /// <seealso cref="APIHelper" />
    /// <seealso cref="RS.Firstrac.DataObjects.ApiIHelper.IFirstracApiHelper" />
    public class FirstracApiHelper : APIHelper, IFirstracApiHelper
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FirstracApiHelper"/> class.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        public FirstracApiHelper(Uri baseUri)
            : base(baseUri)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FirstracApiHelper"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public FirstracApiHelper(APIHelperOptions options) : base(options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FirstracApiHelper"/> class.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        public FirstracApiHelper(Uri baseUri, IHttpClientFactory httpClientFactory) : base(baseUri, httpClientFactory)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FirstracApiHelper"/> class.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="logger">The logger.</param>
        public FirstracApiHelper(Uri baseUri, ILogger<APIHelper> logger) : base(baseUri, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FirstracApiHelper"/> class.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="logger">The logger.</param>
        public FirstracApiHelper(Uri baseUri, IHttpClientFactory httpClientFactory, ILogger<APIHelper> logger) : base(baseUri, httpClientFactory, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FirstracApiHelper"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="logger">The logger.</param>
        public FirstracApiHelper(APIHelperOptions options, IHttpClientFactory httpClientFactory, ILogger<APIHelper> logger) : base(options, httpClientFactory, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FirstracApiHelper"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="logger">The logger.</param>
        public FirstracApiHelper(IOptionsSnapshot<APIHelperOptions> options, IHttpClientFactory httpClientFactory, ILogger<APIHelper> logger) : base(options, httpClientFactory, logger)
        {
        }

        #endregion
    }
}
