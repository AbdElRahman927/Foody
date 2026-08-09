# Flutter Architecture

## Overview

The Foody mobile application follows a **Feature-Based Architecture** designed to keep the application organized, maintainable, and scalable as the project grows.

Each feature should remain as independent as reasonably possible and should contain the code primarily related to that feature.

The architecture prioritizes readability and maintainability over unnecessary abstraction or complexity.

The architecture should evolve gradually as the application becomes more complex. New architectural layers or patterns should only be introduced when they provide clear value.

---

# Project Structure

```text
lib/
│
├── core/
├── features/
├── shared/
└── main.dart
```

---

## core/

The `core` directory contains reusable project-wide infrastructure and technical functionality that is not specific to a particular feature.

Examples include:

* Theme
* App Colors
* Typography
* Constants
* Routing
* Services
* Validators
* Extensions
* Utilities
* Project-wide configuration

### Core Dependency Rule

`core` must not depend on application-specific features.

The dependency direction should generally remain:

```text
features
   ↓
shared / core
```

and not:

```text
core
   ↓
features
```

Core should remain independent and reusable across the application.

---

## features/

The `features` directory contains the main application features.

Each feature should be isolated as much as reasonably possible.

Current and planned examples include:

```text
auth/
home/
restaurant/
reviews/
favorites/
profile/
```

The exact feature structure may evolve as requirements become clearer.

A feature should own the screens, UI logic, data handling, and business logic that are specific to that feature.

---

## shared/

The `shared` directory contains reusable UI components and presentation elements that are not specific to a single feature.

Examples include:

* Reusable Buttons
* Text Fields
* Dialogs
* Loading Widgets
* Empty States
* Error Widgets
* Other generic UI components

### Core vs Shared

The distinction between the two should remain clear:

```text
core/
→ Project-wide technical infrastructure

shared/
→ Reusable UI and presentation components
```

Do not place feature-specific widgets inside `shared`.

---

# Feature Architecture

Each feature may use the following layers depending on its complexity:

```text
feature/
│
├── presentation/
├── domain/
└── data/
```

Not every feature is required to contain all three layers.

Simple features should remain simple.

Additional layers should only be introduced when the feature's complexity justifies them.

The project should avoid implementing a full Clean Architecture structure mechanically for every feature.

---

# Feature Structure

A complex feature may follow a structure similar to:

```text
auth/
│
├── presentation/
│   ├── screens/
│   ├── widgets/
│   └── controllers/
│
├── domain/
│   └── repositories/
│
└── data/
    ├── models/
    └── datasources/
```

This is an example rather than a mandatory structure.

Folders should only be created when they are required.

Avoid:

* Empty folders
* Unused abstractions
* Layers created only for the sake of following a pattern
* Excessive separation in simple features

---

# Presentation Layer

The `presentation` layer contains everything directly responsible for presenting and interacting with the UI.

Examples include:

* Screens
* Feature-specific Widgets
* Controllers
* UI state handling
* User interaction logic

Presentation code should avoid containing unnecessary business or data-access logic.

Large screens should be split into smaller components when doing so improves readability and maintainability.

---

# Domain Layer

The `domain` layer contains feature-specific business concepts and abstractions when they are necessary.

Examples include:

* Repository contracts
* Business rules
* Domain entities
* Feature-specific abstractions

The domain layer should not depend directly on Flutter UI implementation details.

For simple features, a separate domain layer may not be necessary.

---

# Data Layer

The `data` layer handles the feature's data sources and data-related implementation.

Examples include:

* API communication
* Local data sources
* Models
* Data mapping
* Repository implementations

The exact structure may evolve when backend integration begins.

---

# Dependency Direction

Dependencies should generally move toward lower-level reusable functionality.

A feature may depend on:

```text
Feature Presentation
       ↓
Feature Domain
       ↓
Feature Data
       ↓
Core / External Services
```

The exact dependency flow may vary depending on the feature and implementation requirements.

Avoid unnecessary dependencies between unrelated features.

Cross-feature dependencies should be minimized and discussed before introducing them when they can significantly affect the architecture.

---

# State Management

State management is intentionally **not finalized during the current phase**.

The developer is currently learning state-management concepts and will evaluate the appropriate solution before adopting it as a project-wide standard.

Riverpod may be considered as a future option, but it is **not currently a finalized architectural decision**.

Until a state-management solution is selected:

* Keep UI code separated from business logic.
* Avoid placing significant business logic directly inside Widgets.
* Keep feature logic organized so that a state-management solution can be introduced later.
* Do not introduce a state-management package without an explicit project decision.

The state-management decision should be documented once finalized.

---

# Navigation

Navigation should use a centralized routing configuration.

Avoid:

* Scattering route definitions throughout widgets.
* Hardcoding route names repeatedly.
* Duplicating navigation configuration.

The specific routing solution or package is not finalized unless explicitly documented in the project decisions.

Navigation architecture should be introduced gradually as the number of screens grows.

---

# Dependency Injection

Dependency Injection should be introduced only when the application actually requires it.

Avoid adding a dependency injection framework during early development without a clear need.

Simple constructor injection is preferred when it is sufficient.

A dedicated DI solution may be introduced later if application complexity justifies it.

---

# Local Storage

The project will use **SharedPreferences** for simple local application preferences and non-sensitive persistent flags.

Potential use cases include:

* Onboarding completion state
* Simple application preferences
* Non-sensitive local flags
* Other lightweight key-value data

SharedPreferences should not be treated as secure storage.

Sensitive information such as authentication tokens should not be stored there.

If secure persistence is required for authentication or other sensitive information, an appropriate secure storage solution should be evaluated and introduced when the integration requirements are finalized.

---

# Backend Integration

The Flutter application communicates with the Foody backend through the ASP.NET Core Web API.

The expected high-level relationship is:

```text
Flutter Mobile Application
          ↓
   ASP.NET Core API
          ↓
      SQL Server
```

The detailed API communication, repository implementation, authentication flow, error handling, response mapping, and network architecture will be defined as backend integration is introduced.

Do not prematurely introduce complex networking abstractions before they are required.

---

# Folder Naming Convention

Folders use `snake_case`.

Examples:

```text
auth
restaurant_details
forgot_password
complete_profile
```

---

# File Naming Convention

Files use `snake_case`.

Examples:

```text
login_screen.dart
register_screen.dart
auth_repository.dart
custom_button.dart
restaurant_card.dart
```

---

# Widget Guidelines

Widgets should generally have a single responsibility.

Prefer small, focused, reusable widgets when they improve readability.

Large widgets should be considered for extraction when they become difficult to understand or maintain.

Approximately 200 lines may be treated as a warning indicator for reviewing a widget's structure, but this is **not a strict rule**.

Do not split widgets purely to satisfy an arbitrary line count.

---

# Code Organization Rules

Always prioritize:

* Readability
* Maintainability
* Reusability
* Clear separation of responsibilities
* Consistency

Avoid:

* Excessive widget nesting
* Duplicate code
* Large utility classes
* Massive screens
* Unnecessary abstractions
* Premature optimization
* Over-engineering

---

# Scalability Rules

Build what is required by the current project scope.

Do not design complex systems for hypothetical future requirements.

However, current implementations should avoid creating unnecessary technical limitations that would make future feature development unnecessarily difficult.

Features should evolve naturally as requirements grow.

---

# Architecture Evolution

The architecture is not considered permanently fixed.

As the application grows, architectural decisions may change when justified by:

* New requirements
* Increased feature complexity
* Backend integration
* Performance requirements
* Maintainability concerns
* Testing requirements

Significant architectural changes should be documented in:

`docs/08_decisions.md`

The existing architecture should not be changed simply for the sake of introducing a newer pattern or technology.

---

# AI Agent Guidelines

Before implementing a feature, the Agent should:

1. Inspect the existing project structure.
2. Identify the feature's current architecture.
3. Read the relevant documentation.
4. Reuse existing architectural patterns whenever appropriate.
5. Avoid introducing unnecessary layers.
6. Avoid refactoring unrelated features.
7. Create new folders only when they provide clear value.
8. Explain significant architectural changes before applying them.
9. Ask for clarification when an architectural decision is unclear.
10. Keep implementations simple, maintainable, and production-oriented.

The Agent must not assume that a future architectural decision has already been finalized.

When multiple valid architectural approaches exist, the Agent should explain the trade-offs and ask for confirmation before making a project-wide decision.
