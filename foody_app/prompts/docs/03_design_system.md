# Foody Design System

**Version:** 1.0
**Status:** Active
**Last Updated:** 2026-08-07

---

# Design Philosophy

Foody follows a modern, clean, and minimal design language.

The interface should feel warm, welcoming, and easy to use while maintaining a professional appearance.

Every design decision should prioritize:

* Simplicity over complexity.
* Readability over decoration.
* Consistency over creativity.
* User experience over visual effects.

Every screen should feel like a natural part of the same application.

The Design System should guide implementation without preventing reasonable UI decisions when a specific screen requires them.

---

# Brand Identity

**Application Name**

Foody

**Logo**

🍴 Foody

**Primary Font**

Poppins

**Visual Style**

* Modern
* Friendly
* Minimal
* Clean
* Spacious
* Restaurant-focused

---

# Design Tokens

The application uses centralized design tokens.

These values are defined inside the Flutter project and should not be duplicated or hardcoded inside widgets.

Current design tokens include:

* Colors
* Typography
* Spacing
* Border Radius

Future design tokens should follow the same centralized approach.

The implementation inside the Flutter project is the source of truth for the current values.

If the documentation and implementation differ, the Agent must ask the developer for clarification rather than silently choosing one.

---

# Color System

Colors are managed through `AppColors`.

Never hardcode colors inside widgets.

Always reference the centralized color system.

## Current Color Roles

| Color Role     | Purpose                              |
| -------------- | ------------------------------------ |
| Primary        | Primary actions and CTAs             |
| Secondary      | Highlights and accents               |
| Background     | Main scaffold/page background        |
| Surface        | Elevated or separate UI surfaces     |
| Text Primary   | Main readable content                |
| Text Secondary | Supporting or less prominent content |
| Divider        | Section separators                   |
| Border         | Input and component borders          |
| Success        | Success states                       |
| Warning        | Warning states                       |
| Error          | Error states                         |
| Info           | Informational states                 |

Color usage should be semantic rather than based only on the visual appearance of the color.

For example:

* Use `Error` for an error state rather than introducing another red.
* Use `Success` for a success state rather than introducing another green.
* Use `Primary` for primary actions rather than selecting a visually similar orange.

Before introducing a new color, check whether an existing `AppColors` value can satisfy the requirement.

If a genuinely new semantic color is required, discuss it before adding it.

## Background vs Surface

The current application uses:

* `Background` for the main page/scaffold background.
* `Surface` for UI surfaces that need to visually separate themselves from the background.

The current design does not require every card or component to use `Surface`.

Cards, items, and other components may use other existing semantic colors when required by the UI design.

---

# Theme Mode

The current application uses **Light Theme only**.

Dark Theme is currently out of scope.

Do not introduce:

* Dark Theme colors
* Duplicate dark theme structures
* Dark mode switching
* Dark mode-specific components

Dark Theme may be considered in a future phase if the project requires it.

---

# Typography

Typography is managed through `AppTextStyles` and exposed through the application's `ThemeData`.

Never create arbitrary `TextStyle` definitions directly inside widgets.

Prefer:

```dart
Theme.of(context).textTheme
```

The current typography hierarchy is:

| Style          | Usage             |
| -------------- | ----------------- |
| headlineLarge  | Splash Title      |
| headlineMedium | Screen Titles     |
| titleLarge     | Section Titles    |
| titleMedium    | Card Titles       |
| bodyLarge      | Main Content      |
| bodyMedium     | Secondary Content |
| bodySmall      | Captions          |
| labelLarge     | Buttons           |
| labelMedium    | Helper Text       |

The exact font sizes and font weights are defined by the current `AppTextStyles` implementation.

Typography should establish hierarchy rather than act as decoration.

Avoid arbitrary font sizes or weights when an existing text style is appropriate.

Small visual adjustments may be applied using `copyWith()` when required by a specific UI element.

---

# Spacing System

Spacing should remain consistent across the application.

A dedicated `AppSpacing` class may be introduced as the project grows.

Until then, prefer multiples of four.

| Token | Value |
| ----- | ----: |
| XS    |     4 |
| SM    |     8 |
| MD    |    16 |
| LG    |    24 |
| XL    |    32 |
| XXL   |    48 |

These values are design guidelines until a centralized `AppSpacing` implementation is introduced.

Avoid random spacing values when an existing spacing value can satisfy the layout.

---

# Border Radius

Border radius values are managed through `AppRadius`.

Do not introduce arbitrary radius values when an existing radius value is appropriate.

Recommended usage:

| Radius | Usage                      |
| ------ | -------------------------- |
| Small  | Chips and badges           |
| Medium | Buttons, inputs, and cards |
| Large  | Dialogs and bottom sheets  |

The exact values are defined by the current Flutter implementation.

---

# Buttons

Buttons should follow a consistent visual language.

Current button styles include:

### Primary Button

* Filled
* Primary color
* White or appropriate contrasting text

### Secondary Button

* Outlined
* Primary border

### Text Button

* No background
* Used for lower-emphasis actions

Do not introduce additional button styles without a clear UI requirement.

Reusable button components should be preferred when available.

---

# Text Fields

Text fields should follow the global `InputDecorationTheme`.

Current requirements include:

* Rounded corners
* Consistent border
* Primary color when focused
* Error color during validation errors
* Helper text when needed

Avoid styling individual text fields manually when the global theme already provides the required appearance.

Feature-specific customization is acceptable when required by the design.

---

# Dialogs

Dialogs should remain simple, focused, and consistent.

Current use cases include:

* Registration Success
* Logout Confirmation
* Delete Confirmation
* Error Messages

Dialogs should generally contain:

* Clear title
* Short description
* Appropriate primary action

Specific dialog designs may vary when required by the UX.

---

# Feedback States

Features should provide appropriate user feedback when relevant.

Common states include:

* Loading
* Success
* Error
* Empty State
* Validation Error

If a required state has not been defined or its behavior is unclear, discuss it with the developer before implementing it.

---

# Images & Illustrations

Images and illustrations should support the user experience without creating unnecessary visual noise.

Current guidelines:

* Splash Screen uses the Foody logo.
* Onboarding uses custom food-related illustrations.
* Restaurant images are loaded from the backend or demo database.
* Missing images should always display a placeholder.

When a design reference is available, implementation should follow the provided visual design while still respecting the application's Design System.

---

# Responsive Principles

Foody is currently designed as a Mobile-First application.

Layouts should remain flexible across different mobile screen sizes.

Guidelines:

* Respect `SafeArea`.
* Support different screen sizes.
* Avoid fixed heights whenever possible.
* Prefer flexible layouts.
* Avoid unnecessary overflow.
* Do not assume a single device resolution.

---

# Accessibility

The application should remain comfortable and readable.

Guidelines:

* Readable typography.
* Proper color contrast.
* Large and usable tap targets.
* Clear visual hierarchy.
* Consistent spacing.
* Avoid relying only on color to communicate important states.

---

# Visual Hierarchy

Each screen should contain:

* One primary action when applicable.
* One clear focal point.
* Logical content grouping.
* Appropriate whitespace.

Avoid visual clutter.

Visual hierarchy should guide the user toward the intended action without relying on unnecessary decoration.

---

# Design Consistency

New screens should feel like they have always been part of the application.

Avoid introducing:

* New button styles.
* Different spacing systems.
* New typography patterns.
* Inconsistent layouts.
* Unnecessary visual effects.
* New colors without a semantic need.

Maintain consistency across all screens.

---

# UI Consistency Rules

Always follow these rules:

* Never hardcode colors.
* Never hardcode typography.
* Prefer existing design tokens.
* Never duplicate existing components unnecessarily.
* Reuse widgets whenever possible.
* Follow the Design System before creating custom UI.
* Maintain consistent spacing.
* Maintain consistent radius values.
* Extend the existing design language instead of bypassing it.

---

# Component Evolution

Before creating a reusable widget:

1. Search the project.
2. Verify that a similar component does not already exist.
3. Extend an existing component whenever appropriate.
4. Create a new reusable component only when it provides clear long-term value.

Avoid creating nearly identical reusable widgets.

For component-specific rules, refer to:

`04_components.md`

---

# AI Review Process

Before writing any UI code, always follow this workflow.

## Step 1 — Understand

Read:

* `AppTheme`
* `AppColors`
* `AppTextStyles`
* `AppRadius`

Inspect the current implementation.

If documentation and implementation differ, ask the developer before making assumptions.

---

## Step 2 — Inspect

Read the existing feature.

Search for:

* Reusable widgets.
* Reusable components.
* Existing theme usage.
* Existing design patterns.

When a Figma or other design reference is available, inspect it before implementing the UI.

---

## Step 3 — Plan

Summarize your understanding.

List:

* Files to modify.
* New files to create.
* Existing components to reuse.
* Relevant Design System elements.

---

## Step 4 — Clarify

If any requirement is unclear:

**DO NOT ASSUME.**

Instead, ask the developer.

Examples include:

* Missing navigation flow.
* Missing UI behavior.
* Multiple valid implementations.
* Missing validation rules.
* Missing business logic.
* Ambiguous design details.

Wait for clarification when the ambiguity could materially affect the implementation.

---

## Step 5 — Implement

Keep changes minimal.

Respect the project architecture.

Follow the Design System.

Do not modify unrelated code.

---

## Step 5.5 — Self Review

Before finishing:

* Verify Theme usage.
* Verify `AppColors` usage.
* Verify Typography usage.
* Check spacing consistency.
* Check radius consistency.
* Check reusable components.
* Check for duplicated UI.
* Check naming consistency.
* Compare the implementation against the provided design reference when available.
* Verify that no unnecessary design tokens or styles were introduced.

---

## Step 6 — Report

Provide a summary including:

* Files modified.
* Components created.
* Components reused.
* Design System elements used.
* Suggestions for future improvements.

---

# AI Agent Notes

You are acting as a Senior Flutter Engineer working on a production-inspired application.

Your responsibilities extend beyond code generation.

You should:

* Review existing implementations.
* Suggest architectural improvements.
* Recommend reusable abstractions.
* Warn about technical debt.
* Respect previous project decisions.
* Prefer extending existing systems over creating new ones.
* Validate implementation against the existing Design System.

Never rewrite working code unless explicitly requested.

Never introduce unnecessary complexity.

Never implement features outside the current development phase.

If multiple valid implementations exist, explain the trade-offs and ask before proceeding.

Your goal is to collaborate with the developer rather than replace them.

---

# Related Documents

* `01_project_overview.md`
* `02_architecture.md`
* `04_components.md`
* `05_coding_guidelines.md`
* `08_decisions.md`
