# Foody — Current Development Phase

**Current Phase:** Phase 2 — Authentication & Initial User Flow

**Status:** In Progress

**Phase Objective:**
Build the complete authentication flow for the Foody mobile application and establish the initial user entry flow from app launch to the main application.

---

# 1. Current Phase Overview

Phase 2 is focused on implementing the authentication experience of the Foody mobile application.

The goal is to transform the existing UI/UX design into a working Flutter implementation while respecting the project's:

* Architecture
* Design System
* Component System
* Coding Guidelines
* Existing project decisions

This phase starts from the application launch and ends when an authenticated user can successfully reach the main application flow.

The current implementation should focus on Authentication and the screens directly required to support this flow.

Do not implement features belonging to later phases unless they are required to complete the current authentication flow.

---

# 2. Phase Scope

The current phase includes the following areas:

### Application Entry

* Splash Screen
* Initial application launch handling
* Determining the appropriate next screen

### Onboarding

* Onboarding screens
* Food discovery related illustrations
* Navigation between onboarding pages
* Skip/continue actions where applicable
* First-time user experience

### Authentication

* Login
* Registration
* Basic authentication validation
* Registration success feedback
* Navigation between Login and Register

### User Profile Initialization

* Required user information
* Implement only the profile information explicitly required by the approved Auth design
* Email verification flow
* Gender selection
### Authentication Navigation Flow

The intended general flow is:

```text
Application Launch
        ↓
Splash Screen
        ↓
First Launch?
   ┌────┴────┐
   │         │
  Yes        No
   ↓         ↓
Onboarding  Is User Authenticated?
   ↓         ┌────┴────┐
Welcome      │         │
   ↓        Yes        No
Login /      ↓         ↓
Register    Home      Login
   ↓
Authenticated User
   ↓
Main Application
```

### First Launch

For a new user, the intended flow is:

```text
Splash
   ↓
Onboarding
   ↓
Welcome
   ↓
Login / Register
```

The user should not reach the main application until authentication is completed.

### Returning User

For users who have previously opened the application:

* If the user has a valid authenticated session, navigate directly to the Home Screen.
* If the user is not authenticated, such as after logout or session expiration, navigate to the Login Screen.

The application should not show the onboarding flow again after it has been completed.

The exact session and authentication persistence behavior should follow the approved backend authentication contract when integration is implemented.

---

# 3. Authentication Flow

## New User

The intended registration flow is:

```text
Register
   ↓
Enter Required Information
   ↓
Registration Success
   ↓
Authentication / Verification Flow
   ↓
Authenticated User
   ↓
Main Application
```

Registration should contain only the information required to create the account.

Current required registration information includes:

* Name
* Email
* Password
* Gender

Email verification is part of the authentication flow and may be required before the account becomes fully authenticated.

The exact position of Email Verification within the registration and login flow should follow the backend authentication contract.

The mobile application should not assume the verification sequence if the backend contract has not yet been finalized.

The registration screen should not become overloaded with optional profile information.

Optional profile information can be completed later through the user's profile.

### Authentication Flow Rules

* Registration success should provide clear user feedback.
* Email verification should be handled according to the approved authentication flow.
* Authentication state should determine whether the user can enter the main application.
* Do not assume API fields, authentication states, or verification behavior that have not been defined by the backend.
* Backend-dependent behavior should be finalized during the integration stage.

---

# 4. Required User Information

The user must provide the required information needed to identify and manage their account.

Current required information includes:

   registeration feilds:
* Name
* Email
* Password
* Gender

   account verification:
* Email verification

The exact validation rules should follow the backend requirements once authentication integration begins.

Do not invent additional required fields without discussing them first.

---

# 5. Optional Profile Information

Optional information should not block registration or authentication.

Possible optional information includes:

* Profile picture
* Phone number
* Additional profile information

Optional information should be handled through the user's profile / Complete Profile functionality rather than unnecessarily expanding the registration form.

---

# 6. Existing User Flow

For an existing user:

```text
Application Launch
        ↓
Splash Screen
        ↓
Login
        ↓
Authentication
        ↓
Main Application
```

If the user is already authenticated and the backend/session system supports persistent authentication, the application may skip the Login screen and continue to the appropriate authenticated flow.

The exact persistence behavior will be finalized during authentication integration.

---

# 7. Registration Success

After successful registration, the application should display a clear success dialog.

The dialog should:

* Clearly indicate that registration was successful.
* Provide a short confirmation message.
* Guide the user toward the next action.

The current intended behavior is:

```text
Successful Registration
        ↓
Success Dialog
        ↓
Login Screen
```

Do not automatically authenticate the user after registration unless this behavior is explicitly decided later.

---

# 8. Onboarding

Onboarding is intended primarily for first-time users.

The onboarding experience should:

* Introduce the purpose of Foody.
* Explain the main value of the application.
* Use illustrations related to each onboarding concept.
* Maintain the application's visual identity.
* Provide clear navigation between onboarding screens.

The Foody logo should be used for branding where appropriate.

Illustrations should be used for onboarding content rather than replacing the application logo.

---

# 9. Splash Screen

The Splash Screen is the initial entry point of the application.

It should:

* Display the Foody branding.
* Use the approved Foody logo.
* Follow the existing Design System.
* Provide the initial transition into the appropriate application flow.

The Splash Screen should not contain unnecessary functionality.

The Splash Screen should use the approved splash-screen package already selected for the project.

---

# 10. UI / UX Requirements

All screens in this phase must follow:

`03_design_system.md`

and

`04_components.md`

The implementation should match the approved Figma design as closely as practical.

Important visual requirements include:

* Poppins typography.
* Foody color system.
* Consistent spacing.
* Consistent border radius.
* Consistent buttons.
* Consistent input fields.
* Clear visual hierarchy.
* Proper loading and validation feedback.

Do not introduce a new visual style during implementation.

If the implementation conflicts with the Design System or the Figma design, identify the conflict before making a major decision.

---

# 11. Components

Before creating a new component:

1. Search the existing project.
2. Check `04_components.md`.
3. Reuse an existing component when appropriate.
4. Extend an existing component if reasonable.
5. Create a new reusable component only when it provides meaningful value.

Authentication-specific components may include:

* Authentication buttons
* Custom text fields
* Password field
* Gender selection
* Authentication form sections
* Success dialog
* Onboarding indicators
* Onboarding navigation controls

The exact component structure should follow the implementation needs of the feature.

---

# 12. State Management

State Management is intentionally not finalized yet.

For this phase:

* Do not introduce a major state management package without discussion.
* Prefer simple Flutter state where sufficient.
* Keep the implementation structured so a future state management solution can be introduced without unnecessary rewriting.

The final State Management solution will be documented in the relevant project documentation once selected.

---

# 13. Backend Integration

Backend integration is part of the authentication implementation where required.

The mobile application will eventually communicate with the ASP.NET backend for:

* Registration
* Login
* Authentication
* Email verification
* User data

During the UI-first implementation, use appropriate temporary/mock data only where necessary.

Do not create fake backend architecture that conflicts with the actual API structure.

Once the backend API contract is available, the mobile Data Layer should be adapted to the real endpoints.

---

# 14. Data Layer

The Data Layer should remain separated from the presentation layer.

Authentication-related data access should eventually follow the project's architecture defined in:

`02_architecture.md`

The exact API models, repositories, services, and response handling should be implemented according to the actual backend contract.

Do not assume API fields or response formats when they are not known.

During the UI-first stage, backend integration should not block screen implementation unless the UI behavior itself depends on a backend contract.

If backend requirements are unclear, ask before implementation.

---

## Local Persistence

Phase 2 may use SharedPreferences for lightweight local state such as:

- Whether onboarding has been completed.
- Simple first-launch flags.

Do not store sensitive authentication information using SharedPreferences.

Authentication persistence should follow the actual backend/session strategy once integration is implemented.

--

# 15. Validation

Authentication forms should provide appropriate client-side validation.

Validation should cover obvious cases such as:

* Required fields.
* Valid email format.
* Password requirements.
* Password confirmation where applicable.
* Valid gender selection.
* Appropriate error feedback.

Client-side validation does not replace backend validation.

Backend validation should always be treated as authoritative once integration is implemented.

---

# 16. Loading and Error States

Authentication operations should provide appropriate feedback.

Possible states include:

* Idle
* Loading
* Success
* Error
* Validation Error

The UI should prevent confusing interactions during important asynchronous operations.

For example, repeated registration/login submissions should be avoided while a request is already processing.

Error messages should be understandable to the user.

Raw backend or technical errors should not be displayed directly unless intentionally required.

---

# 17. Navigation Rules

Authentication navigation should remain clear and predictable.

Expected navigation relationships include:

```text
Splash
  ↓
Onboarding
  ↓
Login
  ↔
Register
  ↓
Authenticated Flow
```

Registration should return the user to Login after successful registration according to the current project decision.

Optional profile completion should not block the basic registration process unless a future requirement explicitly changes this behavior.

---

# 18. Out of Scope

The following features belong to later phases and should not be implemented as part of Phase 2 unless required for authentication:

* Restaurant Discovery
* Restaurant Categories
* Restaurant Details
* Restaurant Menus
* Restaurant Images
* Reviews
* Ratings
* Favorites
* Restaurant Owner Dashboard
* Admin Dashboard
* Restaurant Registration Approval
* Restaurant Activity Monitoring
* Reservation functionality
* Ordering platform integration
* Advanced search
* Recommendation systems
* Guest Mode

Guest Mode is intentionally postponed and may be considered later if it can be introduced without negatively affecting the existing authentication flow.

---

# 19. Current Development Priorities

Implementation priority should generally follow:

1. Project entry flow.
2. Splash Screen.
3. Onboarding.
4. Login.
5. Register.
6. Registration success feedback.
7. Authentication navigation.
8. Required user information.
9. Email verification flow.
10. Initial authenticated flow.
11. Integration with the backend when the API contract is ready.

The order may change if a technical dependency requires it.

---

# 20. Definition of Done

Phase 2 should be considered functionally complete when:

* [ ] Splash Screen is implemented.
* [ ] Onboarding flow is implemented.
* [ ] Login screen is implemented.
* [ ] Register screen is implemented.
* [ ] Required registration fields are handled.
* [ ] Gender selection is implemented.
* [ ] Client-side validation is implemented.
* [ ] Registration success dialog is implemented.
* [ ] Registration → Login flow works.
* [ ] Login UI and navigation are implemented.
* [ ] Authentication API integration is completed when the backend contract is available.
* [ ] Email verification flow is supported when backend integration is available.
* [ ] Loading states are handled.
* [ ] Error states are handled.
* [ ] UI follows the approved Figma design.
* [ ] UI follows `03_design_system.md`.
* [ ] Existing components are reused where appropriate.
* [ ] No unnecessary packages or architecture were introduced.
* [ ] No features from later phases were implemented unnecessarily.
* [ ] Code follows `05_coding_guidelines.md`.

---

# 21. AI Agent Rules for This Phase

Before implementing any Phase 2 task, the AI Agent must:

1. Read the relevant project documentation.
2. Inspect the existing project structure.
3. Inspect the existing implementation.
4. Check the Design System.
5. Check reusable components.
6. Check current project decisions.
7. Understand the requested screen or feature.
8. Identify files that need to be modified or created.
9. Identify potential conflicts or missing requirements.

If an important requirement is unclear:

**DO NOT ASSUME.**

Ask the developer before implementation.

The AI Agent may:

* Suggest better implementation approaches.
* Point out inconsistencies.
* Identify potential technical problems.
* Recommend reusable components.
* Suggest architectural improvements.

However, it should not:

* Implement future-phase features.
* Introduce unnecessary packages.
* Change the established architecture without discussion.
* Rewrite working code unnecessarily.
* Make major product decisions without approval.

---

# 22. Phase Updates

This file should be updated as Phase 2 progresses.

The status may be changed to reflect the current state:

* Not Started
* In Progress
* Blocked
* Completed

Completed tasks should be marked in the Definition of Done section.

If a significant architectural or product decision is made during the phase, record it in:

`08_decisions.md`

Do not use this file as a permanent decision log.

---

# 23. Phase Completion

When Phase 2 is completed:

1. Review the Definition of Done.
2. Verify that the implementation matches the approved design.
3. Review the code against `05_coding_guidelines.md`.
4. Review reusable components.
5. Document important decisions in `08_decisions.md`.
6. Update `07_future_phases.md` if necessary.
7. Update this file to indicate that Phase 2 is completed.
8. Prepare the project for the next development phase.

The next phase should only begin after the current phase has been reviewed and its remaining issues are understood.
