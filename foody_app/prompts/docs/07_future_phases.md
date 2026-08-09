# Foody — Future Development Phases

**Document Status:** Active

**Purpose:**
This document provides a high-level overview of the upcoming development phases of the Foody mobile application and related systems.

Detailed implementation requirements should be documented in `06_current_phase.md` once a phase becomes active.

---

# Development Strategy

Foody follows a **feature-based development approach**.

Each phase focuses on delivering a specific feature or group of closely related features.

The phases are not necessarily fixed in implementation order. The order may be adjusted when technical dependencies, backend availability, UI/UX requirements, or project decisions require it.

Before starting a new phase:

1. Review the current project state.
2. Review the relevant requirements.
3. Update `06_current_phase.md`.
4. Review `08_decisions.md`.
5. Define the scope and Definition of Done for the phase.

---

# Phase Overview

| Phase   | Feature                            | Status      |
| ------- | ---------------------------------- | ----------- |
| Phase 1 | Project Setup & Design System      | Completed   |
| Phase 2 | Authentication & Initial User Flow | In Progress |
| Phase 3 | Restaurant Discovery               | Planned     |
| Phase 4 | Restaurant Details                 | Planned     |
| Phase 5 | Reviews & Ratings                  | Planned     |
| Phase 6 | Favorites                          | Planned     |
| Phase 7 | Restaurant Owner Dashboard         | Planned     |
| Phase 8 | Admin Dashboard                    | Planned     |

---

# Phase 1 — Project Setup & Design System

**Status:** Completed

### Purpose

Establish the initial project foundation and design system.

### Main Areas

- Flutter project setup.
- Git repository setup.
- Initial project structure.
- Backend and API project preparation where applicable.
- Figma UI/UX design.
- Application branding.
- Color system.
- Typography.
- Theme.
- Border radius system.
- Initial reusable component strategy.
- Documentation structure.

### Output

A clean project foundation ready for feature development.

---

# Phase 2 — Authentication & Initial User Flow

**Status:** In Progress

### Purpose

Implement the complete initial user experience from application launch through authentication.

### Main Areas

- Splash Screen.
- First-launch detection.
- Onboarding.
- Welcome Screen.
- Login.
- Registration.
- Registration success feedback.
- Required user information.
- Gender selection.
- Email verification.
- Authentication state.
- Initial navigation to the Homepage.

### Output

A user should be able to launch Foody, complete the first-time experience, register or log in, and reach the authenticated application flow.

Detailed requirements are maintained in:

`06_current_phase.md`

---

# Phase 3 — Restaurant Discovery

**Status:** Planned

### Purpose

Allow customers to discover restaurants based on their location, interests, and restaurant categories.

### Main Areas

- Homepage.
- Restaurant discovery.
- Restaurant categories.
- Nearby restaurants.
- Search.
- Basic restaurant filtering.
- Restaurant cards.
- Restaurant previews.
- Location-based discovery where supported by the approved requirements and available services.

### Output

Users should be able to discover and search for restaurants that match their interests and location.

---

# Phase 4 — Restaurant Details

**Status:** Planned

### Purpose

Provide users with a complete view of a restaurant and its available information.

### Main Areas

- Restaurant details screen.
- Restaurant information.
- Restaurant images.
- Menu.
- Categories / cuisine information.
- Address and location information.
- Contact information.
- External links.
- Social media links.
- Restaurant website.
- Ordering platform links such as Talabat when available.

### Data Considerations

A sufficiently large demo dataset may be created to represent restaurants during development.

The preferred approach is to keep the demo restaurant data under project control rather than relying entirely on external data sources.

An external restaurant API may be considered if it provides useful and reliable data.

### Output

Users should be able to open a restaurant and access the information needed to understand and interact with it.

---

# Phase 5 — Reviews & Ratings

**Status:** Planned

### Purpose

Allow customers to share their experience and evaluate restaurants.

### Main Areas

- Add review.
- Restaurant rating.
- View reviews.
- Edit existing review.
- Display reviewer information.
- Review validation.
- Review-related loading and error states.

### Output

Users should be able to review restaurants and view reviews submitted by other users.

---

# Phase 6 — Favorites

**Status:** Planned

### Purpose

Allow users to save restaurants they are interested in for easier access later.

### Main Areas

- Add restaurant to favorites.
- Remove restaurant from favorites.
- View favorite restaurants.
- Favorite state on restaurant cards.
- Favorite state on restaurant details.

### Output

Users should be able to maintain and access a personal list of favorite restaurants.

### Note

This phase may be implemented together with Phase 5 if the implementation benefits from combining the related functionality.

---

# Phase 7 — Restaurant Owner Dashboard

**Status:** Planned

**Platform:** Web Dashboard

### Purpose

Allow restaurant owners to register and manage their restaurant information on Foody.

### Main Areas

- Restaurant owner registration.
- Restaurant registration request.
- Restaurant information management.
- Restaurant profile editing.
- Menu management.
- Restaurant image management.
- External links management.
- Social media links.
- Website links.
- Ordering platform links.
- Restaurant status / approval information.

### Approval Flow

Restaurant registration requests should be submitted for review before the restaurant becomes publicly available on Foody.

### Output

Restaurant owners should have a controlled way to submit and manage their restaurant information.

---

# Phase 8 — Admin Dashboard

**Status:** Planned

**Platform:** Web Dashboard

### Purpose

Provide administrators with centralized control over Foody activities and restaurant registration requests.

### Main Areas

- User activity monitoring.
- Restaurant activity monitoring.
- Restaurant registration requests.
- Restaurant approval / rejection.
- Restaurant information review.
- User management where required.
- Administrative monitoring.

### Output

Administrators should be able to monitor the platform and control which restaurants are approved and displayed on Foody.

---

# Cross-Phase Requirements

Some requirements will continue across multiple phases rather than belonging to a single feature.

These include:

### Backend Integration

The Flutter application will communicate with the ASP.NET backend through the project's defined API layer.

### Database

The backend will use SQL Server as the primary database.

### Authentication

Authentication and authorization will be shared across customer, restaurant owner, and administrator flows where applicable.

### UI / UX

All future screens must follow:

`03_design_system.md`

### Reusable Components

Reusable UI components should follow:

`04_components.md`

### Coding Standards

Implementation must follow:

`05_coding_guidelines.md`

### Project Decisions

Important architectural and product decisions must be documented in:

`08_decisions.md`

---

# Phase Transition Rules

When a new phase starts:

1. Update the status of the phase in this document.
2. Move the detailed requirements of the active phase into `06_current_phase.md`.
3. Review the existing architecture.
4. Review relevant design and component documentation.
5. Review previous decisions.
6. Define the scope of the phase.
7. Define its Definition of Done.

When a phase is completed:

1. Mark it as Completed.
2. Review its Definition of Done.
3. Record important decisions in `08_decisions.md`.
4. Update this document if the scope of future phases has changed.
5. Prepare `06_current_phase.md` for the next phase.

---

# Scope Changes

The phase structure is not considered permanently fixed.

A phase may be:

- Expanded.
- Reduced.
- Split into multiple phases.
- Combined with another phase.
- Reordered.

Any significant change should be discussed before implementation.

If the change affects a project-wide decision, record it in:

`08_decisions.md`

---

# AI Agent Instructions

When working on a feature from a future phase:

- Do not implement it before the phase becomes active.
- Use this document to understand the high-level purpose of the phase.
- Do not treat the information here as detailed implementation requirements.
- Once the phase becomes active, use `06_current_phase.md` as the primary source for current scope.
- Review `01_project_overview.md`, `02_architecture.md`, `03_design_system.md`, `04_components.md`, and `08_decisions.md` when relevant.
- If the future phase requirements conflict with the current architecture or project decisions, identify the conflict and ask the developer before implementation.
- Do not implement assumptions based solely on the high-level descriptions in this document.

The goal of this document is to provide direction for upcoming development without prematurely locking implementation details.
