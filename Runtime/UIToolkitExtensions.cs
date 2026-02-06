using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEssentials
{
    public static class UIToolkitExtensions
    {
        // StyleSheet
        public static void AddStyleSheet(this UIDocument document, StyleSheet styleSheet)
        {
            if (styleSheet != null && !document.rootVisualElement.styleSheets.Contains(styleSheet))
                document.rootVisualElement.styleSheets.Add(styleSheet);
        }

        // Border
        public static readonly Color DefaultBorderColor = new(0f, 0f, 0f, 0.2f);
        public static void SetLeftBorder(this VisualElement element, int width, Color? color = null) => SetBorder(element, (width, color ?? DefaultBorderColor));
        public static void SetTopBorder(this VisualElement element, int width, Color? color = null) => SetBorder(element, null, (width, color ?? DefaultBorderColor));
        public static void SetRightBorder(this VisualElement element, int width, Color? color = null) => SetBorder(element, null, null, (width, color ?? DefaultBorderColor));
        public static void SetBottomBorder(this VisualElement element, int width, Color? color = null) => SetBorder(element, null, null, null, (width, color ?? DefaultBorderColor));

        public static void SetBorder(this VisualElement element,
            (int width, Color color)? left = null,
            (int width, Color color)? top = null,
            (int width, Color color)? right = null,
            (int width, Color color)? bottom = null)
        {
            if (left.HasValue)
            {
                element.style.borderLeftWidth = left.Value.width;
                element.style.borderLeftColor = left.Value.color;
            }

            if (top.HasValue)
            {
                element.style.borderTopWidth = top.Value.width;
                element.style.borderTopColor = top.Value.color;
            }

            if (right.HasValue)
            {
                element.style.borderRightWidth = right.Value.width;
                element.style.borderRightColor = right.Value.color;
            }

            if (bottom.HasValue)
            {
                element.style.borderBottomWidth = bottom.Value.width;
                element.style.borderBottomColor = bottom.Value.color;
            }
        }

        // Scrollbar
        public static void SetScrollbarVisibility(this ScrollView scrollView,
            ScrollerVisibility horizontal = ScrollerVisibility.Auto,
            ScrollerVisibility vertical = ScrollerVisibility.Auto)
        {
            scrollView.horizontalScrollerVisibility = horizontal;
            scrollView.verticalScrollerVisibility = vertical;
        }

        // Flex
        public static void SetFlex(this VisualElement element,
            float? grow = null,
            float? shrink = null,
            FlexDirection? direction = null,
            Wrap? wrap = null,
            Justify? justifyContent = null,
            Align? alignItems = null,
            Align? alignSelf = null,
            Align? alignContent = null)
        {
            if (grow.HasValue) element.style.flexGrow = grow.Value;
            if (shrink.HasValue) element.style.flexShrink = shrink.Value;
            if (direction.HasValue) element.style.flexDirection = direction.Value;
            if (wrap.HasValue) element.style.flexWrap = wrap.Value;
            if (justifyContent.HasValue) element.style.justifyContent = justifyContent.Value;
            if (alignItems.HasValue) element.style.alignItems = alignItems.Value;
            if (alignSelf.HasValue) element.style.alignSelf = alignSelf.Value;
            if (alignContent.HasValue) element.style.alignContent = alignContent.Value;
        }

        // Margin
        public static void SetMargin(this VisualElement element, float marginPercent) => SetMargin(element, marginPercent, marginPercent);
        public static void SetMargin(this VisualElement element, int margin) => SetPadding(element, margin, margin);
        public static void SetMargin(this VisualElement element, float horizontalPercent, float verticalPercent) => SetMargin(element, (int)horizontalPercent, (int)verticalPercent);
        public static void SetMargin(this VisualElement element, int horizontal, int vertical) => SetMargin(element, horizontal, horizontal, vertical, vertical);
        public static void SetMargin(this VisualElement element, int left, int right, int top, int bottom)
        {
            element.style.marginLeft = left;
            element.style.marginRight = right;
            element.style.marginTop = top;
            element.style.marginBottom = bottom;
        }

        // Padding
        public static void SetPadding(this VisualElement element, float paddingPercent) => SetPadding(element, paddingPercent, paddingPercent);
        public static void SetPadding(this VisualElement element, int padding) => SetPadding(element, padding, padding);
        public static void SetPadding(this VisualElement element, float horizontalPercent, float verticalPercent) => SetPadding(element, (int)horizontalPercent, (int)verticalPercent);
        public static void SetPadding(this VisualElement element, int horizontal, int vertical) => SetPadding(element, horizontal, horizontal, vertical, vertical);
        public static void SetPadding(this VisualElement element, int left, int right, int top, int bottom)
        {
            element.style.paddingLeft = left;
            element.style.paddingRight = right;
            element.style.paddingTop = top;
            element.style.paddingBottom = bottom;
        }

        // Size
        public static void SetSize(this VisualElement element, Vector2Int size) => SetSize(element, size.x,size.y);
        public static void SetSize(this VisualElement element, Vector2 size) => SetSize(element, (int)size.x, (int)size.y);
        public static void SetSizePercentage(this VisualElement element, Vector2 size) => element.SetSizePercentage(size.x, size.y);
        public static void SetSizePercentage(this VisualElement element, float widthPercent, float heightPercent)
        {
            SetWidthPercentage(element, widthPercent);
            SetHeightPercentage(element, heightPercent);
        }

        public static void SetSize(this VisualElement element, int width, int height)
        {
            SetWidth(element, width);
            SetHeight(element, height);
        }

        public static void SetWidthPercentage(this VisualElement element, float widthPercent) => element.style.width = Length.Percent(widthPercent);
        public static void SetWidth(this VisualElement element, int width) => element.style.width = width;
        public static void SetMinWidthPercentage(this VisualElement element, float widthPercent) => element.style.minWidth = Length.Percent(widthPercent);
        public static void SetMinWidth(this VisualElement element, int width) => element.style.minWidth = width;
        public static void SetMaxWidthPercentage(this VisualElement element, float widthPercent) => element.style.maxWidth = Length.Percent(widthPercent);
        public static void SetMaxWidth(this VisualElement element, int width) => element.style.maxWidth = width;
        
        public static void SetHeightPercentage(this VisualElement element, float heightPercent) => element.style.height = Length.Percent(heightPercent);
        public static void SetHeight(this VisualElement element, int height) => element.style.height = height;
        public static void SetMinHeightPercentage(this VisualElement element, float heightPercent) => element.style.minHeight = Length.Percent(heightPercent);
        public static void SetMinHeight(this VisualElement element, int height) => element.style.minHeight = height;
        public static void SetMaxHeightPercentage(this VisualElement element, float heightPercent) => element.style.maxHeight = Length.Percent(heightPercent);
        public static void SetMaxHeight(this VisualElement element, int height) => element.style.maxHeight = height;

        // Color
        public static void SetColor(this VisualElement element, Color color) => element.style.color = color;
        public static Color SetColorAlpha(this Color color, float alpha) => new Color(color.r, color.g, color.b, alpha);
        public static Color GetColor(this VisualElement element) => element.resolvedStyle.color;

        public static void SetBackgroundColor(this VisualElement element, Color color) => element.style.backgroundColor = color.SetColorAlpha(1);
        public static void SetBackgroundColorWithAlpha(this VisualElement element, Color color) => element.style.backgroundColor = color;

        public static Color GetBackgroundColor(this VisualElement element) => element.resolvedStyle.backgroundColor;

        // Image
        public static void SetBackgroundImage(this VisualElement element, Texture2D texture)
        {
            if (texture != null)
                element.style.backgroundImage = new StyleBackground(texture);
        }

        public static void SetBackgroundImage(this VisualElement element, RenderTexture renderTexture)
        {
            if (renderTexture != null)
                element.style.backgroundImage = new StyleBackground(Background.FromRenderTexture(renderTexture));
        }

        // Display
        public static void SetDisplayEnabled(this VisualElement element, bool enabled) => element.style.display = enabled ? DisplayStyle.Flex : DisplayStyle.None;
        public static bool GetDisplayEnabled(this VisualElement element) => element.resolvedStyle.display != DisplayStyle.None;
        public static void SetVisibility(this VisualElement element, bool visible) => element.style.visibility = visible ? Visibility.Visible : Visibility.Hidden;
        public static Visibility GetVisibility(this VisualElement element) => element.resolvedStyle.visibility;

        // Opacity / Font
        public static void SetOpacity(this VisualElement element, float opacity) =>
            element.style.opacity = Mathf.Clamp01(opacity);

        public static void SetFont(this VisualElement element, FontStyle? style = null, int? size = null)
        {
            if (style.HasValue)
                element.style.unityFontStyleAndWeight = style.Value;

            if (size.HasValue)
                element.style.fontSize = size.Value;
        }
    }
}