﻿namespace YahooScraper.Helpers;

[ContentProperty(nameof(Name))]
[AcceptEmptyServiceProvider]
class TranslateExtension : IMarkupExtension<BindingBase>
{
    public string? Name { get; set; }

    public BindingBase ProvideValue(IServiceProvider serviceProvider)
    {
        return new Binding
        {
            Mode = BindingMode.OneWay,
            Path = $"[{Name}]",
            Source = LocalizationResourceManager.Instance
        };
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return ProvideValue(serviceProvider);
    }
}