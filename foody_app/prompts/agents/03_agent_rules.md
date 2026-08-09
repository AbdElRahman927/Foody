# Foody — AI Agent Rules

## Purpose

This document defines the mandatory rules that AI Agents must follow when working on the Foody project.

These rules protect the project's architecture, consistency, maintainability, security, and development direction.

The Agent must treat these rules as mandatory unless the developer explicitly overrides them.

---

# 1. Understand Before Implementing

The Agent must understand the relevant project context before modifying code.

Do not immediately generate or modify code based only on the developer's latest message.

Before implementation, inspect the relevant:

* Project documentation.
* Existing implementation.
* Architecture.
* Components.
* Current development phase.
* Approved project decisions.
* Design System.

The Agent should understand the existing system before proposing structural changes.

---

# 2. Respect the Current Development Phase

The Agent must work within the scope of the active phase.

The active phase is defined in:

`prompts/docs/06_current_phase.md`

Future phases are documented in:

`prompts/docs/07_future_phases.md`

Do not implement features belonging to future phases unless the developer explicitly requests them.

For example, while working on:

**Phase 2 — Authentication & Initial User Flow**

the Agent must not independently implement:

* Restaurant Discovery.
* Restaurant Reviews.
* Favorites.
* Restaurant Owner features.
* Admin features.

Future functionality may be discussed or planned, but should not be implemented prematurely.

---

# 3. Use the Documentation as Project Context

The Agent should use the documentation to determine as much task context as possible before asking the developer.

The Agent should not ask the developer to manually provide information that can reasonably be determined from the project documentation, current phase, approved decisions, or existing code.

Relevant documentation includes:

```text
prompts/docs/01_project_overview.md
prompts/docs/02_architecture.md
prompts/docs/03_design_system.md
prompts/docs/04_components.md
prompts/docs/05_coding_guidelines.md
prompts/docs/06_current_phase.md
prompts/docs/07_future_phases.md
prompts/docs/08_decisions.md
```

The Agent should not unnecessarily ask the developer for information that is already clearly documented.

---

# 4. Respect the Project Decision Hierarchy

When determining how to implement a task, use this priority:

```text
Developer's Explicit Current Instruction
              ↓
Approved Project Decisions
              ↓
Current Phase Requirements
              ↓
Architecture
              ↓
Design System / Components
              ↓
Coding Guidelines
              ↓
Existing Project Patterns
              ↓
General Engineering Best Practices
```

If a conflict remains after considering this hierarchy, ask the developer instead of silently choosing an interpretation.

---

# 5. Never Assume Important Requirements

The Agent must not guess information that could significantly affect the implementation.

This includes:

* Business rules.
* Authentication behavior.
* Authorization.
* API contracts.
* Database relationships.
* Navigation behavior.
* Data ownership.
* Validation requirements.
* Security behavior.
* Significant UI behavior.
* Major architectural decisions.

When important information is missing, ask the developer.

Minor implementation details that do not affect architecture or application behavior may use reasonable assumptions.

---

# 6. Do Not Silently Resolve Conflicts

If two sources provide conflicting information, do not silently choose one.

Possible sources include:

* Developer instructions.
* Figma.
* Existing code.
* Project documentation.
* Previous decisions.

Identify the conflict clearly.

If the conflict affects architecture, behavior, security, or another significant project decision, stop and ask the developer.

---

# 7. Review Before Refactoring

The Agent must not refactor code simply because it prefers another implementation style.

Before proposing or applying a significant refactor:

1. Inspect the relevant files.
2. Search for related implementations.
3. Understand how the code is currently used.
4. Check related documentation.
5. Identify dependencies and possible side effects.
6. Determine whether the refactor is actually necessary.

Working code should remain unchanged unless the refactor provides meaningful value.

Meaningful reasons include:

* Fixing a bug.
* Removing significant duplication.
* Resolving an architectural problem.
* Improving maintainability.
* Improving testability.
* Supporting a required feature.
* Resolving a significant performance problem.

---

# 8. Minimize Scope

Only modify what is required for the current task.

Avoid:

* Unrelated refactoring.
* Unrequested feature additions.
* Unrelated UI changes.
* Renaming unrelated files.
* Unnecessary architecture changes.
* Unnecessary dependency additions.
* Premature future-phase implementation.

A focused change is preferred over a broad rewrite.

---

# 9. Search Before Creating

Before creating a new:

* Widget.
* Component.
* Service.
* Model.
* Repository.
* Utility.
* Helper.
* Theme value.
* Validation pattern.

search the existing project first.

If an existing implementation can be reused or extended, prefer that approach.

Refer to:

`prompts/docs/04_components.md`

Do not create duplicate implementations that solve essentially the same problem.

---

# 10. Follow the Feature-Based Architecture

The Agent must follow the architecture defined in:

`prompts/docs/02_architecture.md`

The project uses a Feature-Based Architecture where defined by the project architecture.

Features should remain isolated inside their feature directories, and shared infrastructure should belong in the appropriate shared project areas.

Do not introduce additional architectural patterns or layers unless they are required by the approved architecture or explicitly approved by the developer.

Features should remain isolated inside their feature directories.

Shared infrastructure belongs in the appropriate shared project area.

The Agent should respect the existing structure rather than introducing unrelated architectural patterns.

Do not introduce additional architectural layers simply because they are common in other Flutter projects.

Architecture should remain as simple as the current project requires.

---

# 11. Respect Layer Boundaries

When a feature uses layered organization, responsibilities should remain clear.

Typical responsibilities include:

```text
Presentation
    ↓
Domain
    ↓
Data
```

However, not every feature needs all layers.

Do not create empty layers or folders merely to match a theoretical architecture.

Simple features should remain simple.

---

# 12. Follow the Design System

All UI implementation must follow:

`prompts/docs/03_design_system.md`

The Agent must use the project's centralized:

* `AppColors`
* `AppTextStyles`
* `AppTheme`
* `AppRadius`

and follow the established spacing conventions.

Before creating a new UI pattern, search for an existing implementation.

Do not introduce arbitrary colors, typography, spacing, radius values, or component styles.

---

# 13. Never Hardcode Colors

Do not hardcode colors inside widgets.

Incorrect:

```dart
Container(
  color: Color(0xFFF97316),
)
```

Preferred:

```dart
Container(
  color: AppColors.primary,
)
```

If a required semantic color does not exist, determine whether it should be added to the centralized color system.

Do not create one-off colors inside widgets to bypass the Design System.

---

# 14. Never Hardcode Typography

Do not create arbitrary `TextStyle` definitions inside widgets when an existing project style can be used.

Prefer:

```dart
Theme.of(context).textTheme.bodyMedium
```

or the project's existing `AppTextStyles` configuration.

Use `copyWith()` for small local adjustments when necessary.

If a new typography pattern is needed repeatedly, consider extending the centralized typography system instead of duplicating it.

---

# 15. Respect the Theme Architecture

Global theme configuration must remain centralized.

Theme-related changes should be made through the project's established theme system, including:

* `AppTheme`
* `AppColors`
* `AppTextStyles`

Do not bypass the theme with repeated widget-level styling.

Do not introduce a Dark Theme implementation unless explicitly requested.

---

# 16. Reuse Components

Existing reusable components should be preferred over duplicate implementations.

If an existing component is almost suitable:

1. Determine whether it can be extended.
2. Check where it is currently used.
3. Consider whether the extension benefits multiple use cases.
4. Ensure existing behavior will not be broken.

Do not modify a shared component solely for one screen if the change would negatively affect other screens.

---

# 17. Do Not Over-Abstract

Not every widget needs to become a reusable component.

Avoid abstractions that:

* Are used only once.
* Add unnecessary complexity.
* Hide simple UI logic.
* Make the code harder to understand.
* Exist only because reuse might theoretically happen later.

Create reusable components when there is meaningful reuse or clear long-term value.

---

# 18. Respect State Management Status

State management has **not been finalized** for Foody.

The project has intentionally postponed the final state management decision.

Therefore, the Agent must:

* Not assume Riverpod is the final solution.
* Not introduce Riverpod as a project-wide decision.
* Not introduce another state management package as a project-wide solution without approval.
* Keep UI responsibilities separated from business logic.
* Keep state handling easy to migrate when the final solution is selected.
* Prefer simple local state where appropriate for current features.

If a task genuinely requires a project-wide state management decision, explain the available approaches and ask the developer before introducing one.

The postponed state management decision must not block simple feature implementation when local state is sufficient.

---

# 19. Respect Local Storage Decisions

Foody has an approved project decision to use `SharedPreferences` for simple local persistent preferences required by the current project.

The Agent must follow the approved decision documented in:

`prompts/docs/08_decisions.md`

When simple local persistent preferences are required, use:

`SharedPreferences`

Do not introduce another local-storage package for the same purpose without an approved project decision.

Examples of suitable use cases may include:

* First-launch state.
* Simple local preferences.
* Non-sensitive lightweight application settings.

Do not use SharedPreferences for sensitive credentials or data that requires secure storage.

If a requirement needs a different type of storage, explain why the existing decision is insufficient and ask before introducing a new storage solution.

---

# 20. Respect API and Backend Boundaries

The Flutter application must communicate with the backend through the defined API layer.

Do not:

* Access SQL Server directly from Flutter.
* Duplicate backend business logic inside the mobile application.
* Invent backend behavior.
* Hardcode data that should come from the backend.
* Invent API endpoints when integration is required.

If the API contract is missing or unclear, identify the missing information before implementation.

---

# 21. Do Not Invent Data Contracts

Do not invent:

* API request fields.
* API response fields.
* Database fields.
* Authentication claims.
* User roles.
* Error response formats.

If a required contract is missing, ask the developer.

Temporary mock data may be used for UI development when appropriate, but it must remain clearly separated from production API integration.

---

# 22. Authentication and Authorization

Authentication behavior must follow the approved Foody authentication flow.

The Agent must distinguish between:

* First-launch state.
* Onboarding state.
* Authentication state.
* User profile state.
* Authorization / role.

Do not combine these into one unclear condition.

Do not bypass authentication or authorization checks simply to make a feature work.

Authentication-related behavior must not be invented when the backend contract is unclear.

---

# 23. User Data and Privacy

User-related functionality must respect data ownership and privacy.

Do not expose unnecessary personal information.

Do not assume that every user field should be publicly visible.

When implementing user-generated content such as reviews, determine which user information is actually required by the approved UI and backend contract.

Sensitive information must not be stored or logged unnecessarily.

---

# 24. Loading, Error, and Empty States

Where applicable, features should account for:

* Loading.
* Success.
* Error.
* Empty.
* Validation error.
* Retry.

The Agent should not assume that a successful response is the only relevant application state.

If the required behavior is unclear and materially affects the UX, ask the developer.

---

# 25. Validation

User input should be validated appropriately.

Validation must:

* Provide clear feedback.
* Follow the Design System.
* Avoid unnecessary restrictions.
* Match backend requirements when known.

Do not invent validation rules that could conflict with the backend contract.

When requirements are unclear, ask before implementing complex validation behavior.

---

# 26. Navigation

Navigation must follow the established application flow.

Before changing navigation:

* Inspect existing routes.
* Inspect current navigation patterns.
* Check authentication state handling.
* Check whether the destination already exists.
* Avoid creating duplicate navigation mechanisms.

Do not introduce a second routing strategy without an approved project decision.

---

# 27. Dependencies and Packages

Do not add a package simply because it makes a small task easier.

Before adding a dependency, consider:

* Whether Flutter already provides the required functionality.
* Whether the package is actually necessary.
* Whether it is maintained.
* Whether it adds unnecessary complexity.
* Whether it affects application size or performance.
* Whether it conflicts with existing dependencies.

For significant dependencies, explain the reason and trade-offs before adding them.

---

# 28. Performance

Consider performance during implementation without premature optimization.

Avoid:

* Unnecessary rebuilds.
* Repeated expensive operations.
* Unnecessary network requests.
* Loading unnecessarily large resources.
* Inefficient list rendering.

Do not optimize purely theoretical problems without evidence of meaningful impact.

---

# 29. Security

The Agent must not introduce insecure shortcuts.

Never:

* Hardcode secrets.
* Store sensitive credentials in source code.
* Bypass authentication.
* Trust client-side authorization alone.
* Expose sensitive API information unnecessarily.
* Log sensitive user data.
* Store sensitive credentials in SharedPreferences.

Security-sensitive decisions should be discussed before implementation.

---

# 30. Figma and UI Accuracy

When a Figma design is provided:

* Use it as the primary visual reference for the requested screen.
* Follow the Foody Design System.
* Reuse existing components where possible.
* Avoid introducing project-wide styling changes for one screen.

If Figma conflicts with an established project-wide decision, identify the conflict.

Ask the developer when the conflict affects project-wide behavior or architecture.

---

# 31. Code Quality

Code should be:

* Readable.
* Maintainable.
* Consistent.
* Properly structured.
* Appropriately named.
* Free from unnecessary duplication.

Prefer simple, understandable solutions over clever or unnecessarily abstract solutions.

---

# 32. Comments

Comments should explain **why**, not simply repeat **what** the code does.

Do not add comments for obvious code.

Use comments when they clarify:

* Non-obvious business logic.
* Important technical constraints.
* Temporary workarounds.
* Significant implementation decisions.

---

# 33. Error Handling

Do not silently ignore errors.

Errors should be:

* Handled appropriately.
* Communicated to the user when necessary.
* Logged appropriately when useful.
* Separated from sensitive information.

Do not expose raw technical errors directly to users.

---

# 34. Testing and Verification

After implementation, verify the affected functionality according to the task.

Verification may include:

* Static analysis.
* Running the application.
* Testing the affected screen.
* Testing navigation.
* Testing validation.
* Testing loading and error states.
* Testing API integration.
* Reviewing affected code.

The Agent must never claim that something was tested if it was not actually tested.

---

# 35. No Fake Completion

The Agent must never claim that a feature is:

* Fully implemented.
* Fully tested.
* Fully integrated.
* Production-ready.

unless the available evidence supports that statement.

If something remains incomplete, state what remains.

---

# 36. No Unrequested Future Work

Do not implement future enhancements simply because they are technically easy.

Examples include:

* Dark Mode.
* Guest Mode.
* Advanced filtering.
* Recommendation systems.
* Advanced analytics.
* Future dashboard functionality.
* Features belonging to later development phases.

These may be suggested as future work but must remain outside the current implementation unless explicitly requested.

---

# 37. Developer Control

The developer has final authority over project decisions.

The Agent should:

* Recommend.
* Explain.
* Warn.
* Ask.
* Implement after sufficient clarity.

The Agent must not silently make significant project-wide decisions.

---

# 38. Decision Documentation

When a significant approved decision changes the project, document it in:

`prompts/docs/08_decisions.md`

Examples include:

* Technology choices.
* State management decisions.
* Local storage decisions.
* Authentication architecture.
* API conventions.
* Major architectural changes.
* Project-wide UI decisions.

Do not create duplicate decision documentation in unrelated files.

---

# 39. Documentation Consistency

The Agent should not knowingly leave contradictions between:

* Code.
* Architecture.
* Design System.
* Components.
* Current Phase.
* Future Phases.
* Decisions.
* Agent documentation.

If a task makes documentation inaccurate, identify the affected documents.

If the required update is a direct consequence of an already-approved change, the Agent may update the relevant documentation.

If the update represents a new project decision, obtain developer approval before recording it as an approved decision.

---

# 40. Review Before Applying Project-Wide Changes

When a proposed change may affect multiple files or features, do not immediately modify the first file that exposes the problem.

First:

1. Inspect the relevant project files.
2. Search for all affected usages.
3. Review related documentation.
4. Identify the full scope of the issue.
5. Determine whether the change should be applied now or deferred.
6. Discuss significant changes with the developer.

If several files need review before deciding on a refactor, complete the review first and make the change afterward.

Avoid repeated cycles of:

```text
Inspect one file
↓
Modify it
↓
Discover another issue
↓
Modify another file
↓
Repeat
```

Prefer:

```text
Review relevant files
↓
Understand the complete picture
↓
Identify required changes
↓
Decide what belongs to the current phase
↓
Apply the agreed changes
```

This reduces unnecessary rework and prevents the project from becoming trapped in continuous refactoring.

---

# 41. Deferred Improvements

Not every identified improvement must be implemented immediately.

If the Agent discovers a valid improvement that:

* Is not required for the current feature.
* Does not cause a current bug.
* Does not create a significant architectural problem.
* Belongs more naturally to a future phase.

the Agent should document or report it as a potential future improvement rather than implementing it automatically.

The developer may decide whether to:

* Implement it now.
* Defer it to the next phase.
* Reject it.

Deferred improvements should be reported in the final task summary when they are relevant.

The Agent should not create or modify future-phase documentation merely to record minor implementation ideas.

---

# 42. Stop Conditions

The Agent should stop and ask the developer when:

* A major requirement is ambiguous.
* Two project decisions conflict.
* The API contract is missing and cannot be safely inferred.
* A database change is required but not defined.
* A significant architectural change is required.
* Authentication behavior is unclear.
* Security implications are unclear.
* Multiple approaches have materially different consequences.
* The requested change conflicts with the current phase.
* Figma conflicts significantly with project rules.
* A change may affect multiple existing features and its full impact is not yet understood.

---

# 43. Priority Order

When deciding how to implement a task, use this priority:

```text
Developer's Explicit Current Instruction
              ↓
Approved Project Decisions
              ↓
Current Phase Requirements
              ↓
Architecture
              ↓
Design System / Components
              ↓
Coding Guidelines
              ↓
Existing Project Patterns
              ↓
General Engineering Best Practices
```

If a conflict remains after considering the priority order, ask the developer.

---

# Final Rule

The Agent should follow this principle throughout Foody development:

> **Understand the complete context first, follow the approved decisions, implement only what the current phase requires, and defer non-essential improvements instead of continuously refactoring the project.**
