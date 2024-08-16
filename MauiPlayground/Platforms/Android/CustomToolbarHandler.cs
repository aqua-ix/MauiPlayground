using Android.Content;
using Android.Runtime;
using Android.Util;
using Google.Android.Material.AppBar;
using MauiPlayground.Views;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Prism.Common;
using Prism.Controls;
using AView = Android.Views.View;
using AViewGroup = Android.Views.ViewGroup;

namespace MauiPlayground;

public class CustomToolbarHandler : ToolbarHandler
{
    protected override MaterialToolbar CreatePlatformElement()
    {
        var context = MauiContext?.Context ?? throw new InvalidOperationException("Context cannot be null");
        var toolbar = new CustomToolbar(context);
        ConfigureToolbar(toolbar, context.GetActionBarHeight(), -1);

        return toolbar;
    }

    // ref: https://github.com/dotnet/maui/blob/8.0.40/src/Core/AndroidNative/maui/src/main/java/com/microsoft/maui/PlatformInterop.java#L203-L214
    public static void ConfigureToolbar(MaterialToolbar toolbar, int actionBarHeight, int popupTheme)
    {
        var layoutParams = new AppBarLayout.LayoutParams(AViewGroup.LayoutParams.MatchParent, actionBarHeight);
        layoutParams.ScrollFlags = 0;
        toolbar.LayoutParameters = layoutParams;

        if (popupTheme > 0)
        {
            toolbar.PopupTheme = popupTheme;
        }
    }

    protected override void ConnectHandler(MaterialToolbar platformView)
    {
        base.ConnectHandler(platformView);

        if (platformView is CustomToolbar toolbar)
        {
            toolbar.CustomNavigationOnClickListener = new CustomOnClickListener(NavigationClick);
        }
    }

    protected override void DisconnectHandler(MaterialToolbar platformView)
    {
        if (platformView is CustomToolbar toolbar)
        {
            toolbar.CustomNavigationOnClickListener = null;
        }

        base.DisconnectHandler(platformView);
    }

    private void NavigationClick()
    {
        var page = FindCurrentPage(VirtualView);
        if (page is INavigateUpHandler handler)
        {
            handler.OnNavigateUpButtonPressed();
        }

        FindAncestor<PrismNavigationPage>(page)?.SendBackButtonPressed();
    }

    public static T? FindAncestor<T>(IElement? element) where T : Element
    {
        var parent = element?.Parent;
        while (parent != null)
        {
            if (parent is T p)
            {
                return p;
            }

            parent = parent.Parent;
        }

        return null;
    }

    public static Page? FindCurrentPage(IElement element)
    {
        if (FindAncestor<Window>(element) is { } window)
        {
            // ref: https://github.com/PrismLibrary/Prism.Maui/blob/8.1.273-pre/src/Prism.Maui/Navigation/PrismWindow.cs#L20
            return MvvmHelpers.GetCurrentPage(window.Page);
        }

        return null;
    }

    private class CustomOnClickListener(Action action) : Java.Lang.Object, AView.IOnClickListener
    {
        public void OnClick(AView? v)
        {
            action.Invoke();
        }
    }

    public class CustomToolbar : MaterialToolbar
    {
        private IOnClickListener? _customNavigationOnClickListener;

        internal IOnClickListener? CustomNavigationOnClickListener
        {
            get => _customNavigationOnClickListener;
            set
            {
                _customNavigationOnClickListener = value;
                base.SetNavigationOnClickListener(value);
            }
        }

        protected CustomToolbar(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CustomToolbar(Context context) : base(context)
        {
        }

        public CustomToolbar(Context context, IAttributeSet? attrs) : base(context, attrs)
        {
        }

        public CustomToolbar(Context context, IAttributeSet? attrs, int defStyleAttr) : base(context, attrs,
            defStyleAttr)
        {
        }

        public override void SetNavigationOnClickListener(IOnClickListener? listener)
        {
        }
    }
}