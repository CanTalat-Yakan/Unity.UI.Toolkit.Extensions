# Unity Essentials

This module is part of the Unity Essentials ecosystem and follows the same lightweight, editor-first approach.
Unity Essentials is a lightweight, modular set of editor utilities and helpers that streamline Unity development. It focuses on clean, dependency-free tools that work well together.

All utilities are under the `UnityEssentials` namespace.

```csharp
using UnityEssentials;
```

## Installation

Install the Unity Essentials entry package via Unity's Package Manager, then install modules from the Tools menu.

- Add the entry package (via Git URL)
    - Window → Package Manager
    - "+" → "Add package from git URL…"
    - Paste: `https://github.com/CanTalat-Yakan/UnityEssentials.git`

- Install or update Unity Essentials packages
    - Tools → Install & Update UnityEssentials
    - Install all or select individual modules; run again anytime to update

---

# UI Toolkit Extensions

> Quick overview: Handy extension methods for `UIDocument` and `VisualElement` to streamline common UI Toolkit tasks: add style sheets once, set size in pixels or percent, tweak text/background color (with alpha helpers), set background images (Texture2D/RenderTexture), and toggle display/visibility.

A small set of pragmatic helpers that reduce boilerplate when working with UI Toolkit. These extensions wrap typical style assignments with clear, intention‑revealing methods and safe checks (like avoiding duplicate style sheet adds).

![screenshot](Documentation/Screenshot.png)

## Features
- StyleSheet utilities
  - `UIDocument.AddStyleSheet(StyleSheet)` – adds once to `rootVisualElement.styleSheets`
- Size helpers (pixels or percent)
  - `SetSize(Vector2)`, `SetSize(float widthPercent, float heightPercent)`, `SetSize(int width, int height)`
  - `SetWidth(float percent|int px)`, `SetHeight(float percent|int px)`
- Color utilities
  - Text color: `SetColor(Color)`, `GetColor()`
  - Background: `SetBackgroundColor(Color)` (forces alpha 1), `SetBackgroundColorWithAlpha(Color)`, `GetBackgroundColor()`
  - Color math: `Color.SetColorAlpha(alpha)` returns a new color with adjusted alpha
- Background image helpers
  - `SetBackgroundImage(Texture2D)` and `SetBackgroundImage(RenderTexture)`
- Display/visibility toggles
  - `SetDisplayEnabled(bool)` / `GetDisplayEnabled()` → `DisplayStyle.Flex` vs `None`
  - `SetVisibility(bool)` / `GetVisibility()` → `Visibility.Visible` vs `Hidden`

## Requirements
- Unity 6000.0+
- UI Toolkit (`UIDocument`, `VisualElement`)

## Usage

### Add a stylesheet once
```csharp
using UnityEngine;
using UnityEngine.UIElements;
using UnityEssentials;

var doc = GetComponent<UIDocument>();
var ss = Resources.Load<StyleSheet>("MyGlobalStyles");
doc.AddStyleSheet(ss); // ignored if already present
```

### Set size (percent or pixels)
```csharp
VisualElement panel = root.Q<VisualElement>("panel");

// Percent
panel.SetSize(100f, 100f);    // 100% x 100%
panel.SetWidth(50f);          // 50% width

// Pixels
panel.SetSize(320, 180);
panel.SetHeight(256);
```

### Colors and backgrounds
```csharp
var label = root.Q<Label>("title");
label.SetColor(new Color(1f, .9f, .4f));

var bg = root.Q<VisualElement>("backdrop");
bg.SetBackgroundColor(new Color(.1f, .1f, .1f, 1f));     // force opaque
bg.SetBackgroundColorWithAlpha(new Color(.1f, .1f, .1f, .6f)); // keep alpha

var current = label.GetColor();
var faded = current.SetColorAlpha(0.5f);
label.SetColor(faded);
```

### Background images
```csharp
var img = root.Q<VisualElement>("splash");
var tex = Resources.Load<Texture2D>("Textures/Logo");
img.SetBackgroundImage(tex);

var rt = new RenderTexture(512, 512, 0);
img.SetBackgroundImage(rt);
```

### Display vs visibility
```csharp
var popup = root.Q<VisualElement>("popup");

// Remove from layout vs hide but keep layout
popup.SetDisplayEnabled(false);           // display: none
popup.SetVisibility(false);               // visibility: hidden

// Read current state
bool shown = popup.GetDisplayEnabled();
var vis = popup.GetVisibility();
```

## How It Works
- These are thin wrappers around `VisualElement.style` and `resolvedStyle` properties
- Percent sizes use `Length.Percent(x)`, pixel sizes assign ints directly
- Background images are assigned via `StyleBackground` or `Background.FromRenderTexture`
- `AddStyleSheet` checks containment before adding to avoid duplicates

## Notes and Limitations
- `resolvedStyle` is read‑only and reflects computed values after layout; reads may lag until the next layout pass
- Setting styles directly overrides USS values; prefer class‑based styling for theme consistency and use these helpers for dynamic adjustments
- Background images expect `Texture2D`/`RenderTexture`; for vector images or sprite atlases, use appropriate TMP or Sprite assets separately
- UI Toolkit styling is main‑thread only; call these from the main thread/UI context

## Files in This Package
- `Runtime/UIToolkitExtensions.cs` – Extension methods for `UIDocument`/`VisualElement`
- `Runtime/UnityEssentials.UIToolkitExtensions.asmdef` – Runtime assembly definition
- `package.json`, `LICENSE.md`

## Tags
unity, ui toolkit, uitoolkit, visualelement, uxml, uss, extensions, style, color, background, display, visibility
