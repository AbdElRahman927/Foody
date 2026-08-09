# Foody Components

**Version:** 1.0
**Status:** Active
**Last Updated:** 2026-08-07

---

# Purpose

This document defines the reusable UI components used throughout the Foody mobile application.

Its purpose is to:

* Maintain UI consistency.
* Reduce duplicated UI code.
* Encourage appropriate reuse.
* Define clear component responsibilities.
* Prevent unnecessary component abstractions.

This document describes both currently implemented components and planned component candidates.

A component listed here must not be implemented automatically unless it belongs to the current development phase or is explicitly requested.

---

# Component Philosophy

Reusable components should be:

* Simple.
* Focused.
* Easy to understand.
* Easy to extend.
* Consistent with the Design System.
* Independent from feature-specific business logic whenever possible.

Components should primarily focus on presentation and UI behavior.

Business logic belongs to the appropriate feature layer.

A component should not become reusable only because it is technically possible to reuse it.

Create abstractions when they provide clear value, reduce duplication, or establish an important application-wide UI pattern.

---

# Component Scope

Components can exist at different levels.

## Feature Components

Feature-specific widgets belong inside their feature.

Example:

```text
features/
└── auth/
    └── presentation/
        └── widgets/
```

A widget can be reusable within the Auth feature without becoming a global component.

---

## Shared Components

Truly application-wide UI components belong inside the shared layer.

Examples:

* Global buttons.
* Global text fields.
* Loading indicators.
* Empty states.
* Error states.
* Common dialogs.

A component should only become shared when it has a clear application-wide purpose.

Do not move feature-specific widgets into `shared/` simply because they are reusable.

---

# Component Status

Each component should have one of the following statuses.

| Status      | Meaning                                              |
| ----------- | ---------------------------------------------------- |
| Planned     | Identified as potentially useful but not implemented |
| In Progress | Currently being developed                            |
| Implemented | Implemented and approved for reuse                   |
| Deprecated  | Existing component should no longer be used          |

`Planned` components are not implementation requirements.

`Implemented` components may still evolve when legitimate requirements arise.

---

# Component Definition

Before creating a reusable component, clearly identify:

* Component name.
* Purpose.
* Scope.
* Where it is used.
* Required properties.
* Optional properties.
* Callbacks.
* Supported states.
* Visual behavior.
* Design System dependencies.

The component API should remain as small and clear as possible.

Avoid exposing unnecessary configuration options.

---

# General Rules

Always search for an existing component before creating a new one.

Search:

1. The current feature.
2. The shared component directory.
3. This document.

If an existing component can reasonably be extended, prefer extending it over creating another similar component.

Avoid creating multiple widgets that solve the same problem.

Never duplicate existing UI patterns unnecessarily.

Prefer composition over inheritance.

Keep components small and focused.

Do not create abstractions for hypothetical future requirements.

Do not move components between feature and shared scope without a clear reason.

---

# Design System Integration

Reusable components must follow the Foody Design System.

Components should use:

* `AppTheme`
* `AppColors`
* `AppTextStyles`
* `AppRadius`

Do not hardcode:

* Colors.
* Typography.
* Arbitrary border radii.
* Unnecessary spacing values.

Prefer theme-provided styling whenever appropriate.

Component-specific styling is acceptable when required by the design, but it should remain consistent with the overall Design System.

Refer to:

`03_design_system.md`

for detailed UI rules.

---

# Component States

Reusable components should support relevant states when applicable.

Examples:

* Default.
* Disabled.
* Loading.
* Error.
* Selected.
* Focused.
* Empty.

Do not implement states that are not required by the component.

If the required behavior is unclear, ask the developer before implementation.

---

# Buttons

## Primary Button

**Status:** Planned

**Purpose**

Main call-to-action button.

**Used In**

* Authentication.
* Forms.
* Dialogs.
* Other primary user actions.

**Behavior**

* Uses the global theme.
* Uses the primary color.
* Supports disabled state.
* Supports loading state when required.

**Notes**

Should be the default filled button for primary actions.

---

## Secondary Button

**Status:** Planned

**Purpose**

Secondary actions that should have lower visual emphasis than the primary action.

**Behavior**

* Outlined appearance.
* Uses the existing Design System.
* Supports disabled state.

---

## Text Button

**Status:** Planned

**Purpose**

Low-emphasis actions.

**Behavior**

* No filled background.
* Uses theme typography and colors.

---

# Input Components

## App Text Field

**Status:** Planned

**Purpose**

Default reusable text input.

**Supports**

* Validation.
* Label.
* Hint.
* Prefix.
* Suffix.
* Error message.
* Enabled/disabled state.

**Design Requirements**

Should follow the global `InputDecorationTheme`.

Avoid duplicating input decoration styling inside individual screens.

---

## Password Field

**Status:** Planned

**Purpose**

Password input with visibility control.

**Supports**

* Password obscuring.
* Visibility toggle.
* Validation.
* Error state.

Should reuse the behavior and styling of `AppTextField` where appropriate instead of duplicating its implementation.

---

## Search Field

**Status:** Planned

**Purpose**

Restaurant search input.

This component may remain feature-specific until search behavior and requirements are finalized.

Do not move it into the shared layer without a clear application-wide need.

---

# Selection Components

## Radio Group

**Status:** Planned

**Purpose**

Single-choice selection.

**Current Example**

Gender selection during registration.

The component should support:

* Selected value.
* Available options.
* Selection callback.
* Appropriate visual feedback.

The visual design must follow the provided UI design and the Foody Design System.

---

## Checkbox Tile

**Status:** Planned

**Purpose**

Single boolean selection displayed as a reusable tile.

**Current Example**

Terms & Conditions acceptance.

---

## Dropdown

**Status:** Planned

**Purpose**

Single-value selection from a list.

This component is not required for the current Auth implementation unless explicitly requested.

---

# Cards

## Restaurant Card

**Status:** Planned

**Purpose**

Displays a restaurant summary.

**Expected Content**

* Image.
* Restaurant name.
* Rating.
* Category.
* Distance when available.
* Favorite action when required.

The exact layout should follow the approved design reference.

---

## Review Card

**Status:** Planned

**Purpose**

Displays a user review.

---

## Category Card

**Status:** Planned

**Purpose**

Displays a restaurant category.

---

# Navigation Components

## Section Header

**Status:** Planned

**Purpose**

Reusable section title and optional supporting action.

---

## Custom App Bar

**Status:** Future

**Purpose**

Global application app bar.

Do not implement during the current phase unless explicitly requested.

---

## Bottom Navigation

**Status:** Future

**Purpose**

Main application navigation.

Do not implement during the current phase unless explicitly requested.

---

# Feedback Components

## Loading Indicator

**Status:** Planned

**Purpose**

Reusable loading state.

Should remain visually consistent across the application.

---

## Empty State

**Status:** Planned

**Purpose**

Displayed when a screen or feature has no content to display.

---

## Error State

**Status:** Planned

**Purpose**

Displays a user-friendly error state.

Should provide an appropriate recovery action when applicable.

---

## Success Dialog

**Status:** Planned

**Purpose**

Communicates that an operation completed successfully.

**Current Example**

Registration completed successfully.

The dialog should follow the global dialog and Design System rules.

---

## Confirmation Dialog

**Status:** Planned

**Purpose**

Requests confirmation before destructive or important actions.

---

## Snackbar

**Status:** Planned

**Purpose**

Provides short, non-blocking feedback.

---

# Media Components

## App Avatar

**Status:** Future

**Purpose**

Displays profile images.

---

## Network Image

**Status:** Future

**Purpose**

Reusable network image handling.

Should eventually provide appropriate loading and failure behavior.

---

## Image Placeholder

**Status:** Future

**Purpose**

Fallback UI when an image is unavailable.

---

## Image Carousel

**Status:** Future

**Purpose**

Displays restaurant image galleries.

---

# Restaurant Components

## Rating Widget

**Status:** Future

**Purpose**

Displays restaurant ratings.

---

## Category Chip

**Status:** Future

**Purpose**

Displays restaurant categories as compact selectable or informational elements.

---

## Price Indicator

**Status:** Future

**Purpose**

Displays restaurant pricing information.

---

## Restaurant Status Badge

**Status:** Future

**Purpose**

Displays restaurant availability status such as Open or Closed.

---

# Component Evolution Rules

Before creating any reusable widget:

1. Search the current feature.
2. Search the shared components.
3. Search this document.
4. Verify whether an existing component can be reused.
5. Verify whether an existing component can be extended.
6. Determine whether the component is feature-specific or application-wide.
7. Verify that abstraction provides meaningful value.
8. Confirm that the component follows the Design System.
9. Implement only what is required by the current phase.

Avoid creating components solely for hypothetical future reuse.

---

# AI Component Review Process

Before creating a reusable component, follow this workflow.

## Step 1 — Search

Search for existing:

* Widgets.
* Shared components.
* Feature components.
* Similar UI implementations.

---

## Step 2 — Determine Scope

Decide whether the component should be:

* Local to the current screen.
* Reusable within the feature.
* Shared across the application.

Do not promote a component to the shared layer without a clear reason.

---

## Step 3 — Check the Design System

Verify:

* Colors.
* Typography.
* Spacing.
* Border radius.
* Theme usage.
* Accessibility requirements.

---

## Step 4 — Define the API

Before implementation, determine:

* Required properties.
* Optional properties.
* Callbacks.
* Supported states.
* Necessary configuration.

Keep the public API minimal.

---

## Step 5 — Clarify

If the component's behavior, scope, or visual requirements are unclear:

**DO NOT ASSUME.**

Ask the developer before implementation.

---

## Step 6 — Implement

Implement only the required behavior.

Keep the component:

* Small.
* Focused.
* Readable.
* Reusable where appropriate.

Do not introduce unrelated abstractions.

---

## Step 7 — Validate

Before marking a component as implemented:

* Verify Design System compliance.
* Verify all required states.
* Verify accessibility.
* Verify responsive behavior where relevant.
* Verify that no existing component was unnecessarily duplicated.
* Verify naming and file organization.
* Compare against the provided design reference when available.

---

# AI Agent Notes

You are responsible for maintaining a scalable but intentionally small component library.

Do not introduce reusable widgets unnecessarily.

Avoid over-engineering.

Favor consistency over excessive flexibility.

Prefer composition over complex inheritance.

Keep the component API minimal.

Do not implement components only because they are listed as `Planned` or `Future`.

Always respect the current development phase.

Never implement components for future phases unless explicitly requested.

When multiple valid component designs exist, explain the trade-offs and ask the developer before making a significant architectural decision.

---

# Related Documents

* `02_architecture.md`
* `03_design_system.md`
* `05_coding_guidelines.md`
* `06_current_phase.md`
* `08_decisions.md`
