// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


namespace IdentityServerAspNetIdentity.Pages.Account.Register;

public class ViewModel
{
    public bool AllowRememberLogin { get; set; } = true;
    public bool EnableLocalAccount { get; set; } = true;

    public IEnumerable<ViewModel.ExternalProvider> ExternalProviders { get; set; } = Enumerable.Empty<ExternalProvider>();
    public IEnumerable<ViewModel.ExternalProvider> VisibleExternalProviders => ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));

    public bool IsExternalAccountOnly => EnableLocalAccount == false && ExternalProviders?.Count() == 1;
    public string ExternalLoginScheme => IsExternalAccountOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;
        
    public class ExternalProvider
    {
        public string DisplayName { get; set; }
        public string AuthenticationScheme { get; set; }
    }
}