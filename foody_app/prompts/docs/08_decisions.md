# Foody — Project Decisions

## Purpose

This document records important product, architectural, technical, and development decisions made throughout the Foody project.

The purpose is to preserve the reasoning behind important decisions so that future development remains consistent and previously discussed decisions are not accidentally changed.

This document should answer:

* What was decided?
* Why was it decided?
* What alternatives were considered?
* What is the current status of the decision?

---

# Decision Status

Each decision should have one of the following statuses:

* **Active** — Currently applies to the project.
* **Proposed** — Suggested but not officially approved.
* **Superseded** — Replaced by a newer decision.
* **Deprecated** — No longer relevant to the project.

Only Active decisions should be treated as current project rules.

---

# Decision Format

When adding a new decision, use the following structure:

```text
## DEC-XXX — Decision Title

Status: Active

Date: YYYY-MM-DD

### Context

What problem or requirement led to this decision?

### Decision

What was decided?

### Reason

Why was this approach selected?

### Alternatives Considered

What other approaches were considered?

### Impact

What parts of the project are affected?

### Related Files

Which documentation or implementation areas are related to this decision?
```

---

# Active Decisions

## DEC-001 — Feature-Based Development

**Status:** Active

### Context

Foody contains multiple independent but connected features across the mobile application, backend, and web dashboards.

### Decision

The project will follow a **feature-based development approach**.

Each development phase will focus on delivering a specific feature or a closely related group of features.

### Reason

Feature-based development allows the project to be developed incrementally while keeping each phase focused and easier to test and review.

### Impact

Development phases are organized around features rather than purely technical layers.

The current and future phases are documented in:

* `06_current_phase.md`
* `07_future_phases.md`

---

## DEC-002 — Mobile Application Technology

**Status:** Active

### Context

The customer-facing application requires a cross-platform mobile solution.

### Decision

The Foody mobile application will be developed using **Flutter and Dart**.

### Reason

Flutter provides a suitable cross-platform development environment and allows the project to maintain a consistent UI across supported mobile platforms.

### Impact

Mobile UI, navigation, state management, and presentation logic will be implemented using Flutter.

---

## DEC-003 — Backend Technology

**Status:** Active

### Context

Foody requires a backend API to handle authentication, business logic, data access, and communication with the mobile and web applications.

### Decision

The backend will be developed using **ASP.NET / ASP.NET Core**.

### Reason

ASP.NET provides a structured environment for developing REST APIs and integrating with SQL Server.

### Impact

The mobile and web applications will communicate with the backend through the defined API layer.

---

## DEC-004 — Database

**Status:** Active

### Context

Foody requires persistent storage for users, restaurants, reviews, favorites, and other application data.

### Decision

**SQL Server** will be used as the primary database.

### Reason

SQL Server provides a relational database model that is suitable for the relationships and structured data required by Foody.

### Impact

Database design and backend data access will be based around SQL Server.

---

## DEC-005 — Web Dashboard Technology

**Status:** Active

### Context

Restaurant owners and administrators require a web-based interface for management tasks.

### Decision

The web dashboards will be developed using **React**.

### Reason

A web dashboard is more suitable than a mobile interface for management tasks involving larger amounts of information and administrative operations.

### Impact

The project will contain web-based interfaces for:

* Restaurant Owners
* Administrators

---

## DEC-006 — Authentication and Initial User Flow

**Status:** Active

### Context

Foody needs to distinguish between first-time users, returning users with an active session, and users who need to authenticate again.

### Decision

The initial mobile application flow will follow:

```text
First Launch

Splash
  ↓
Onboarding
  ↓
Welcome
  ├── Login
  └── Register
```

Returning users will follow:

```text
Splash
  ↓
Session Check
  ├── Valid Session → Homepage
  └── No Valid Session → Login
```

### Reason

Onboarding should be shown only to first-time users, while returning authenticated users should be able to reach the main application without unnecessarily repeating the onboarding or login process.

### Impact

The application needs to distinguish between:

* First-launch / onboarding completion state.
* Authentication / session state.

These states should not be treated as the same condition.

---

## DEC-007 — Registration Flow

**Status:** Active

### Context

The registration process needs to collect the information required to identify the user without making the registration form unnecessarily large.

### Decision

The Register screen will contain the required account information.

Optional profile information will be available later through the user's profile.

After successful registration, the application will display a success dialog and then direct the user to Login.

```text
Register
   ↓
Registration Success
   ↓
Success Dialog
   ↓
Authentication / Verification Flow
```

### Reason

Separating required account information from optional profile information keeps the registration process simpler and reduces unnecessary friction.

### Impact

Optional profile information does not block account creation.

---

## DEC-008 — Guest Mode

**Status:** Proposed

### Context

A guest mode could allow users to explore Foody without creating an account.

### Decision

Guest Mode will **not be implemented during the current authentication phase**.

It may be reconsidered later if it can be introduced without creating significant authentication, authorization, or data-ownership complications.

### Reason

The current project scope focuses on establishing a clear authenticated user flow first.

### Impact

Users currently follow the defined authentication flow before accessing authenticated functionality.

---

## DEC-009 — Light Theme

**Status:** Active

### Context

Foody needs a consistent visual theme during the initial development phases.

### Decision

The application will initially support **Light Mode only**.

Dark Mode will not be implemented during the current development scope.

### Reason

The current Figma design and initial implementation are based on a light visual theme.

Dark Mode can be introduced later without affecting the current feature development.

### Impact

The current ThemeData and Design System should be designed cleanly enough to support future theme expansion.

---

## DEC-010 — Centralized Design System

**Status:** Active

### Context

Multiple screens and features need to maintain the same visual language.

### Decision

Colors, typography, spacing conventions, border radius, and common UI behavior will be centralized through the Foody Design System.

### Reason

Centralization prevents inconsistent styling and reduces duplicated UI definitions.

### Impact

Developers and AI Agents should use:

* `AppColors`
* `AppTextStyles`
* `AppTheme`
* `AppRadius`
* Reusable components

instead of creating independent styles inside individual screens.

---

## DEC-011 — Reusable Components

**Status:** Active

### Context

Multiple screens may require similar UI elements.

### Decision

Reusable components should be created when they provide meaningful long-term value.

Existing components must be reused or extended before creating a new similar component.

### Reason

This reduces duplication and helps maintain visual and behavioral consistency.

### Impact

Before creating a new reusable widget, the existing project should be searched first.

Component rules are documented in:

`04_components.md`

---

## DEC-012 — AI Agent Collaboration Model

**Status:** Active

### Context

AI Agents are being used to assist with development, but the developer remains responsible for project decisions and implementation oversight.

### Decision

AI Agents should act as **development collaborators**, not autonomous code generators.

The agent should:

* Read the relevant project documentation.
* Inspect the existing implementation.
* Understand the current phase.
* Identify potential problems.
* Suggest alternatives when appropriate.
* Ask questions when important requirements are unclear.
* Avoid unnecessary changes.

### Reason

Understanding the project before implementation reduces incorrect assumptions, rework, and unnecessary technical debt.

### Impact

Agent behavior is further defined in the `agents` documentation.

---

## DEC-013 — Local Storage

**Status:** Active

### Context

The application requires lightweight local persistence during the initial user flow, particularly for first-launch and onboarding state.

### Decision

Foody will use `SharedPreferences` for simple local key-value storage.

It will initially be used for:

- First-launch detection.
- Onboarding completion state.
- Other non-sensitive local preferences when required.

`SharedPreferences` should not be used for sensitive authentication credentials or secure secrets.

### Reason

The current requirements only require simple local key-value persistence. `SharedPreferences` provides a lightweight solution without introducing unnecessary storage complexity.

### Impact

Phase 2 may use `SharedPreferences` for first-launch and onboarding state.

If future requirements introduce more complex or sensitive local storage needs, the storage solution should be reconsidered based on those requirements.

--

## DEC-014 — State Management

**Status:** Active

### Context

The project will require a dedicated state management solution as the application grows.

The developer has not finalized the state management approach yet.

### Decision

State management selection is intentionally postponed.

No state management package should be introduced during the current phase unless explicitly approved by the developer.

The current implementation should keep UI, local state, and business logic reasonably separated so that a future state management solution can be introduced without unnecessary refactoring.

### Reason

State management is currently a new area for the developer and requires evaluation and understanding before committing the project to a specific solution.

Delaying the decision avoids introducing unnecessary dependencies or architectural assumptions prematurely.

### Impact

Phase 2 should avoid committing to Riverpod, Bloc, Provider, or another state management framework.

The decision will be revisited when the project reaches a point where centralized or more advanced state management is required.

--

# Decision Management Rules

## Adding a Decision

A decision should be added when it has meaningful impact on:

* Architecture.
* Technology.
* Product behavior.
* Development workflow.
* UI/UX standards.
* Data handling.
* Authentication.
* Project structure.

Minor implementation details do not need to be recorded here.

---

## Changing a Decision

Do not silently modify an existing Active decision.

If an existing decision needs to change:

1. Review the original decision.
2. Explain why it is no longer suitable.
3. Create a new decision.
4. Mark the previous decision as **Superseded**.
5. Reference the new decision.

Example:

```text
DEC-005 — Previous Decision
Status: Superseded

Superseded by:
DEC-014 — New Decision
```

This preserves the project's decision history.

---

## Proposed Decisions

A proposed decision must not be treated as a project rule until it is explicitly approved.

AI Agents may suggest proposed decisions when they identify:

* Architectural improvements.
* Better implementation approaches.
* Potential technical risks.
* Missing project rules.

However, the agent should ask the developer before treating a proposed decision as Active.

---

# AI Agent Instructions

When making a decision that may affect the project beyond the current implementation:

1. Check this file first.
2. Check whether an existing decision already addresses the issue.
3. Do not contradict an Active decision without discussing it.
4. If multiple valid approaches exist, explain the trade-offs.
5. Ask the developer before introducing a significant new project decision.
6. Record approved significant decisions using the standard format.

The AI Agent should prefer consistency with existing project decisions over introducing new patterns.

---

# Related Documentation

This file works together with:

* `01_project_overview.md`
* `02_architecture.md`
* `03_design_system.md`
* `04_components.md`
* `05_coding_guidelines.md`
* `06_current_phase.md`
* `07_future_phases.md`

The `agents` documentation defines how AI Agents should use these project documents during development.
