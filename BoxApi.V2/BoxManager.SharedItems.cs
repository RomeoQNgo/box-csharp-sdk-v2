﻿using System;
using BoxApi.V2.Model;

namespace BoxApi.V2
{
    public partial class BoxManager
    {
        /// <summary>
        /// Gets information about a shared item.
        /// </summary>
        /// <typeparam name="T">The shared item's type (File or Folder)</typeparam>
        /// <param name="sharedLinkUrl">The link to the shared item (SharedLink.Url)</param>
        /// <param name="fields">The properties that should be set on the returned File/Folder object.  Type and Id are always set.  If left null, all properties will be set, which can increase response time.</param>
        /// <returns>The shared File/Folder</returns>
        /// <remarks>The user does not need an authorization token to use this method. Only the API key and shared link url are required.</remarks>
        public T GetSharedItem<T>(string sharedLinkUrl, Field[] fields = null) where T : ShareableEntity, new()
        {
            var request = _requestHelper.Get(ResourceType.SharedItem, fields);
            return _restClient.WithSharedLink(sharedLinkUrl).ExecuteAndDeserialize<T>(request);
        }

        /// <summary>
        /// Gets information about a shared item.
        /// </summary>
        /// <typeparam name="T">The shared item's type (File or Folder)</typeparam>
        /// <param name="onSuccess">Action to perform with the shared item</param>
        /// <param name="onFailure">Action to perform on a failed Shared Item operation</param>
        /// <param name="sharedLinkUrl">The link to the shared item (SharedLink.Url)</param>
        /// <param name="fields">The properties that should be set on the returned File/Folder object.  Type and Id are always set.  If left null, all properties will be set, which can increase response time.</param>
        /// <remarks>The user does not need an authorization token to use this method. Only the API key and shared link url are required.</remarks>
        public void GetSharedItem<T>(Action<T> onSuccess, Action<Error> onFailure, string sharedLinkUrl, Field[] fields = null) where T : ShareableEntity, new()
        {
            var request = _requestHelper.Get(ResourceType.SharedItem, fields);
            _restClient.WithSharedLink(sharedLinkUrl).ExecuteAsync(request, onSuccess, onFailure);
        }
    }
}