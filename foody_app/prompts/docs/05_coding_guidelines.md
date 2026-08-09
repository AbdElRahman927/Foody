# Foody Coding Guidelines

**Version:** 1.0
**Status:** Active
**Last Updated:** 2026-08-08

---

## Purpose

This document defines the coding standards and development practices used throughout the Foody mobile application.

Its purpose is to keep the codebase:

* Clean
* Consistent
* Readable
* Maintainable
* Scalable
* Easy to understand for both developers and AI agents

These guidelines should be followed when creating new features, modifying existing code, or refactoring the application.

---

## General Philosophy

Foody follows these general coding principles:

* Readability over clever code.
* Simplicity over unnecessary complexity.
* Consistency over personal preference.
* Reusability when it provides real value.
* Separation of responsibilities.
* Avoid premature optimization.
* Avoid premature abstraction.
* Keep changes focused on the requested feature.
* Do not introduce architecture or technologies that have not been agreed upon.

Code should be easy for another developer to understand without requiring unnecessary explanation.

---

## Project Structure

The project follows a feature-oriented structure.

Features should be organized according to their responsibility rather than placing all files of the same type in global folders.

Features should only contain the architectural layers required by their current complexity.

The exact structure should follow the project's current architecture.

Do not introduce a new folder structure without checking the existing architecture first.

Before creating a new file:

1. Inspect the existing feature structure.
2. Identify where similar files are located.
3. Follow the established project pattern.
4. Avoid creating new structural patterns for individual features.

---

## Naming Conventions

### Files

Use `snake_case`.

Examples:

```text
login_screen.dart
auth_repository.dart
user_model.dart
app_colors.dart
```

Avoid:

```text
LoginScreen.dart
loginScreen.dart
UserModel.dart
```

### Classes

Use `PascalCase`.

Examples:

```dart
LoginScreen
AuthRepository
UserModel
AppColors
```

### Variables and Methods

Use `camelCase`.

Examples:

```dart
userName
isLoading
getUserProfile()
validateEmail()
```

### Constants

Use descriptive names and follow the project's existing constant style.

Do not create unclear abbreviations.

### Naming Principles

Names should describe their responsibility clearly.

Prefer:

```text
RestaurantCard
PasswordField
AuthRepository
```

Avoid:

```text
CustomWidget
Helper
Manager
DataHandler
Widget2
```

Do not use generic names when a more specific name is possible.

---

## File Organization

Dart files should remain focused on a clear responsibility.

Avoid placing unrelated classes, widgets, models, or utilities in the same file.

When a file becomes difficult to understand or maintain, consider extracting a meaningful component.

However, do not split files unnecessarily.

The goal is clear responsibility, not a large number of small files.

---

## Widget Guidelines

Widgets should primarily be responsible for UI and presentation.

Avoid placing business logic directly inside UI widgets.

Widgets should:

* Display data.
* Receive required information.
* Handle UI interactions.
* Trigger appropriate actions.

Business rules, data access, and complex processing should be handled by the appropriate layer.

### Widget Reusability

Do not create reusable widgets for every small UI element.

Before creating a reusable widget:

1. Search the project.
2. Check `04_components.md`.
3. Verify that a similar component does not already exist.
4. Determine whether the widget provides real reusable value.
5. Determine whether the component is feature-specific or application-wide.

If the widget is only used once and has no clear reuse value, keeping it local to the feature may be preferable.

---

## UI and Design System

All UI implementation must follow:

`03_design_system.md`

Reusable UI components must follow:

`04_components.md`

Never introduce:

* Hardcoded colors.
* Random typography.
* Arbitrary spacing systems.
* Arbitrary border radiuses.
* New button styles without justification.

Use the existing Design System whenever possible.

---

## Colors

Never hardcode application colors inside widgets.

Use:

```dart
AppColors
```

for application colors.

If a new recurring color is required:

1. Check whether an existing color can be reused.
2. If not, discuss whether it should be added to `AppColors`.
3. Add it centrally instead of repeatedly hardcoding it.

---

## Typography

Do not create repeated `TextStyle` objects directly inside widgets.

Prefer:

```dart
Theme.of(context).textTheme
```

and the project's `AppTextStyles`.

Small screen-specific adjustments may use:

```dart
copyWith()
```

when necessary.

Do not create new global text styles for minor one-off visual adjustments.

---

## Spacing and Radius

Follow the spacing and radius systems defined by the Design System.

Prefer existing spacing and radius values.

Avoid arbitrary values when an existing project value already satisfies the requirement.

---

## Business Logic

Business logic should not be placed directly inside presentation widgets.

Avoid:

```text
UI
↓
Complex business rules
↓
Database/API
```

Instead, responsibilities should remain separated according to the project's architecture.

The exact implementation should follow:

`02_architecture.md`

Do not introduce additional architectural layers unless there is a clear reason.

---

## Models

Models should represent application data clearly.

Models should remain independent from UI concerns whenever possible.

Avoid placing:

* Navigation logic.
* UI rendering.
* Snackbars.
* Dialog presentation.
* `BuildContext`-dependent logic.

inside data models.

Model implementation should follow the conventions already established in the project.

---

## Services

Services should have a clear responsibility.

A service should not become a general-purpose class containing unrelated functionality.

Avoid placing UI responsibilities inside services.

Services should not directly:

* Display SnackBars.
* Show dialogs.
* Navigate between screens.
* Depend on `BuildContext`.

---

## Repository and Data Access

Data access should remain separated from the presentation layer.

UI widgets should not directly contain database or API access logic.

When backend integration is introduced, follow the existing data architecture instead of creating feature-specific shortcuts.

Do not introduce duplicate data-access patterns.

---

## State Management

The project's final state management solution has not been established yet.

Until a state management approach is officially selected:

* Do not introduce a state management package without approval.
* Do not create a project-wide state management pattern prematurely.
* Use simple local Flutter state where appropriate.
* Keep state-related code easy to migrate later.

Once the state management solution is selected, this section should be updated with the official project guidelines.

---

## Local Storage

SharedPreferences is the current preferred solution for simple local key-value storage.

Use it for lightweight local application data such as:

- First-launch / onboarding state.
- Simple user preferences.
- Non-sensitive local flags.

Do not use SharedPreferences for:

- Authentication secrets.
- Complex structured databases.
- Large datasets.
- Sensitive information.

Before introducing another local storage solution, discuss the requirement with the developer.

---

## Navigation

Navigation should remain within the presentation/application flow rather than being distributed randomly throughout the codebase.

Avoid placing navigation logic inside:

* Models
* Repositories
* Services
* Data classes

Follow the project's established navigation solution once it is finalized.

---

## Error Handling

Errors should never be silently ignored.

Avoid:

```dart
catch (e) {}
```

unless there is a documented reason.

Errors should be:

* Handled appropriately.
* Communicated to the user when necessary.
* Logged when useful for debugging.
* Converted into meaningful UI states when appropriate.

Do not expose raw technical errors to users unless intentionally required.

---

## Loading and Feedback States

Features that perform asynchronous operations should consider appropriate states.

Possible states include:

* Loading
* Success
* Error
* Empty
* Validation Error

Do not add unnecessary states when they provide no meaningful UX value.

Follow the Design System for displaying these states.

---

## Comments

Prefer self-explanatory code over excessive comments.

Comments should explain:

* Why something is implemented in a specific way.
* Important constraints.
* Non-obvious decisions.
* Temporary workarounds.

Comments should not simply describe obvious code.

Prefer:

```dart
// Keep the delay to prevent repeated requests while the user is typing.
```

over:

```dart
// This starts a timer.
```

If a workaround is temporary, explain why it exists and, when possible, what should eventually replace it.

---

## Performance

Performance should be considered during implementation without introducing premature optimization.

Prefer:

* Efficient widget trees.
* Appropriate use of `const`.
* Reusable widgets.
* Avoiding unnecessary rebuilds.
* Proper handling of asynchronous operations.
* Appropriate image handling.

Do not optimize code without identifying an actual or reasonably expected performance issue.

Avoid sacrificing readability for minor theoretical performance improvements.

---

## Packages and Dependencies

Do not add a package simply because it provides a convenient shortcut.

Before introducing a new package:

1. Check whether Flutter already provides the required functionality.
2. Check whether the project already contains a package that solves the problem.
3. Consider whether the package is actively maintained.
4. Consider whether the package introduces unnecessary complexity.
5. Explain the reason for adding it.

If the package affects architecture or introduces a major dependency, discuss it before implementation.

---

## Refactoring

Do not refactor working code without a clear reason.

Refactoring may be appropriate when:

* Code is duplicated.
* A clear bug exists.
* Responsibilities are mixed.
* The existing implementation prevents the requested feature.
* Maintainability is significantly affected.

Keep refactoring focused.

Avoid changing unrelated parts of the application while implementing a feature.

---

## Feature Scope

Respect the current development phase.

Do not implement future features simply because their code could be prepared in advance.

Avoid building unnecessary infrastructure for features that have not started.

If a future requirement affects the current implementation, document the concern and discuss it before introducing additional complexity.

Refer to:

`06_current_phase.md`

and

`07_future_phases.md`

---

## Code Review Checklist

Before considering a task complete, review the implementation against the following checklist.

* [ ] Current architecture is respected.
* [ ] Current development phase is respected.
* [ ] Existing components were searched and reused when appropriate.
* [ ] Design System rules are respected.
* [ ] No unnecessary hardcoded colors.
* [ ] No unnecessary hardcoded `TextStyle` objects.
* [ ] Naming conventions are respected.
* [ ] No unnecessary duplicated code.
* [ ] No unnecessary abstractions.
* [ ] No unnecessary packages were introduced.
* [ ] Business logic is separated from UI where appropriate.
* [ ] Error states are handled appropriately.
* [ ] Loading states are handled where necessary.
* [ ] No unrelated files were modified.
* [ ] The implementation remains readable and maintainable.

---

## AI Review Process

Before writing or modifying code, the AI Agent should:

### Step 1 — Understand

Read the relevant project documentation.

At minimum, consider:

* `01_project_overview.md`
* `02_architecture.md`
* `03_design_system.md`
* `04_components.md`
* `06_current_phase.md`
* `08_decisions.md`

Read the relevant source files before making implementation decisions.

### Step 2 — Inspect

Search the existing project for:

* Similar widgets.
* Existing components.
* Existing models.
* Existing services.
* Existing utilities.
* Existing patterns.

Do not assume that a required implementation does not already exist.

### Step 3 — Analyze

Before implementation, determine:

* What needs to change.
* Which files will be modified.
* Which files may need to be created.
* Which existing components can be reused.
* Whether the requested implementation conflicts with existing architecture or decisions.

### Step 4 — Ask

If important information is missing or multiple valid approaches exist:

**DO NOT ASSUME.**

Ask the developer before implementing.

Examples:

* Missing business rules.
* Ambiguous navigation flow.
* Conflicting architectural patterns.
* Missing validation requirements.
* Multiple reasonable implementation approaches.
* Documentation and implementation disagree.

The AI may propose alternatives and explain trade-offs before asking for a decision.

### Step 5 — Implement

After requirements are clear:

* Make focused changes.
* Follow the established architecture.
* Reuse existing components.
* Follow the Design System.
* Avoid unrelated refactoring.
* Avoid unnecessary dependencies.

### Step 6 — Review

After implementation:

* Review the modified code.
* Check for obvious errors.
* Check consistency with project guidelines.
* Run appropriate analysis/tests when available.
* Review the Code Review Checklist.

### Step 7 — Report

After completing the task, summarize:

* Files modified.
* Files created.
* Components reused.
* Components created.
* Important implementation decisions.
* Any issues discovered.
* Any recommendations for future work.

---

## AI Agent Notes

The AI Agent is a development collaborator, not a code generator.

The agent is expected to:

* Understand the project before modifying it.
* Identify potential problems.
* Suggest better solutions when appropriate.
* Explain meaningful trade-offs.
* Protect the existing architecture.
* Respect previous project decisions.
* Point out technical debt.
* Avoid unnecessary complexity.

The agent may disagree with an implementation approach when there is a valid technical reason.

However, it should explain the reason and allow the developer to make the final decision.

Never rewrite working code simply to match a personal preference.

Never introduce unnecessary architecture.

Never implement features outside the current phase without explicit approval.

---

## Related Documents

* `01_project_overview.md`
* `02_architecture.md`
* `03_design_system.md`
* `04_components.md`
* `06_current_phase.md`
* `07_future_phases.md`
* `08_decisions.md`
