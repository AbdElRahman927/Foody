# Foody — AI Prompt Templates

## Purpose

This document contains reusable prompt templates for common development tasks in the Foody project.

The templates provide the Agent with a structured way to approach common tasks without requiring the developer to manually repeat information that already exists in the project documentation or codebase.

The Agent must continue to follow:

* `agents/01_agent_overview.md`
* `agents/02_agent_workflow.md`
* `agents/03_agent_rules.md`
* Relevant files inside `docs/`

These templates define **how to communicate a task**, not the project's architecture or development rules.

---

# How to Use These Templates

Before using a template:

1. Select the template that best matches the task.
2. Provide the task in natural language.
3. Include additional information only when it is not already available from the project context.
4. Provide Figma references, screenshots, API contracts, error messages, or other external information when required.
5. Allow the Agent to inspect the project before implementation.

### Context Inference

The Agent should determine information from the available project context whenever possible.

This includes information such as:

* Current development phase.
* Feature scope.
* Relevant files.
* Existing screens.
* Existing components.
* Existing navigation.
* Existing architecture.
* Existing design-system values.
* Existing project decisions.

Empty optional fields should **not** automatically trigger questions.

If the required information can be safely determined from the project, the Agent should determine it independently.

If important information cannot be determined safely, the Agent should ask the developer before implementation.

### Developer-Provided Information

The developer should explicitly provide information when it is:

* A new requirement not documented in the project.
* A specific business rule.
* A specific behavior that cannot be inferred.
* An API contract not available in the project.
* A Figma reference that is not accessible to the Agent.
* An explicit exception to an existing project rule.
* A significant project decision that has not yet been approved.

### Optional Context Fields

Some templates contain fields such as:

```text
Additional Context:
Figma Reference:
Expected Behavior:
Constraints:
```

These fields are optional.

Leave them empty when the Agent can obtain the required information from the project.

The Agent should not ask the developer to manually fill information that is already available.

---

# 01 — New Screen

Use when implementing a new Flutter screen.

```text
I want to implement a new screen in the Foody mobile application.

Screen:

Purpose:

Figma Reference:

Additional Context:

Before writing code:

1. Read the relevant project documentation.
2. Identify the current development phase.
3. Determine whether this screen belongs to the current phase.
4. Inspect the existing project structure.
5. Search for similar screens and reusable components.
6. Inspect the existing navigation flow.
7. Inspect AppTheme, AppColors, AppTextStyles, and AppRadius.
8. Review relevant project decisions.

Infer missing information from the project whenever possible.

Do not ask me for information that can be safely determined from the project.

Before implementation:

- Explain your understanding of the screen.
- Identify the relevant existing files.
- Identify files that need modification.
- Identify files that need to be created.
- Identify reusable components.
- Identify navigation requirements.
- Identify important dependencies or risks.

If an important requirement cannot be determined safely, ask me before implementation.

Otherwise, implement the smallest correct solution according to the existing project architecture and Design System.
```

---

# 02 — Modify Existing Screen

Use when changing an existing screen.

```text
I want to modify an existing Foody screen.

Screen:

Current File:

Requested Change:

Additional Context:

Before modifying the code:

1. Inspect the current implementation.
2. Identify the current behavior.
3. Read the relevant project documentation.
4. Check the current development phase.
5. Search for related reusable components.
6. Inspect navigation and dependencies.
7. Check the Design System usage.
8. Review relevant project decisions.

Infer missing information from the existing project whenever possible.

Do not rewrite the screen unnecessarily.

Before implementation, briefly identify:

- What currently exists.
- What needs to change.
- Which files are affected.
- Which existing components can be reused.
- Whether navigation or shared behavior is affected.
- Any important risks.

If the requested behavior cannot be determined safely, ask me before making the change.

Otherwise, implement only the required changes.
```

---

# 03 — Implement From Figma

Use when a Figma design is the primary visual reference.

```text
Implement the relevant Foody screen based on the provided Figma design.

Screen:

Figma Reference:

Additional Context:

Before implementation:

1. Inspect the Figma design carefully.
2. Read `docs/03_design_system.md`.
3. Inspect AppColors.
4. Inspect AppTextStyles.
5. Inspect AppTheme.
6. Inspect AppRadius.
7. Search for existing reusable components.
8. Inspect existing screen and navigation patterns.
9. Check relevant project decisions.
10. Confirm that the screen belongs to the current development phase.

The Figma design is the primary visual reference for the requested screen.

However:

- Follow the established Foody Design System.
- Reuse existing components whenever possible.
- Do not introduce project-wide styling changes for a single screen.
- Do not create duplicate components.
- Do not silently change established project decisions.

If Figma conflicts with an important project decision, identify the conflict before making a significant change.

Infer screen structure, component usage, and implementation details from the available project context whenever possible.

Before coding, provide a concise implementation plan.

If no important clarification is required, proceed with implementation.
```

---

# 04 — Debugging

Use when something is not working correctly.

```text
I have a problem in the Foody project.

Problem:

Expected Behavior:

Actual Behavior:

Relevant File(s):

Error Message:

Additional Context:

Before changing code:

1. Inspect the relevant implementation.
2. Reproduce or trace the behavior when possible.
3. Identify the root cause.
4. Check related architecture, navigation, state, API integration, and UI behavior where relevant.
5. Search for similar implementations.
6. Avoid changing unrelated code.

Do not immediately patch the visible symptom.

First determine:

- Root cause.
- Responsible code.
- Why the problem occurs.
- Safest correction.
- Potential side effects.

If the cause cannot be determined safely, ask for the missing information.

Otherwise, implement the smallest appropriate fix.

After implementation, verify that the fix does not introduce a regression.
```

---

# 05 — Refactoring

Use when improving existing code structure.

```text
I want to refactor part of the Foody project.

Target:

Reason:

Constraints:

Additional Context:

Before refactoring:

1. Inspect the current implementation.
2. Read the relevant architecture documentation.
3. Identify duplication and structural problems.
4. Search for existing reusable patterns.
5. Check whether the affected code is used elsewhere.
6. Review relevant project decisions.
7. Determine whether the refactor is actually necessary.

Do not refactor simply because another coding style appears preferable.

Before making a significant refactor, explain:

- Current problems.
- Proposed structure.
- Benefits.
- Risks.
- Files affected.
- Potential breaking changes.

Do not introduce a significant architectural change without developer approval.

Preserve existing behavior unless the requested task explicitly changes it.

Keep the refactor focused on the identified problem.
```

---

# 06 — Create or Improve Reusable Component

Use when a UI element may need to become reusable.

```text
I want to create or improve a reusable component for Foody.

Component:

Purpose:

Current Usage:

Additional Context:

Before creating or modifying the component:

1. Search the project for similar components.
2. Read `docs/04_components.md`.
3. Inspect the Design System.
4. Determine whether an existing component can be reused or extended.
5. Determine whether the abstraction provides meaningful long-term value.
6. Check whether the component belongs in `shared/` or should remain feature-specific.

Do not create a reusable component merely because the UI appears reusable.

If an existing component is sufficient, reuse it.

If a new component is justified, determine:

- Responsibility.
- API / parameters.
- Location.
- Expected reuse.
- Design System dependencies.

If the correct scope is unclear, ask before creating a project-wide component.

Otherwise, implement the smallest reusable solution.
```

---

# 07 — API Integration

Use when connecting a Flutter feature to the ASP.NET backend.

```text
I want to integrate the relevant Foody feature with the ASP.NET backend.

Feature:

API / Documentation:

Request Details:

Expected Response:

Additional Context:

Before implementation:

1. Inspect the existing data layer.
2. Inspect existing API services.
3. Inspect models and repositories.
4. Check authentication requirements.
5. Check existing error handling.
6. Check loading and empty states.
7. Search for similar API integrations.
8. Review the relevant architecture and project decisions.

Do not invent:

- API endpoints.
- Request fields.
- Response fields.
- Authentication claims.
- Database fields.
- Error response formats.

Use contracts already available in the project.

If the API contract is incomplete or unavailable and cannot be safely inferred, identify exactly what is missing and ask before implementation.

Before implementation, provide a concise summary of:

- Data flow.
- Models required.
- Existing services to reuse.
- Files affected.
- Integration risks.

Then implement the integration according to the existing architecture.
```

---

# 08 — State Management Task

Use when state management becomes an active implementation requirement.

```text
I want to implement or modify state handling for a Foody feature.

Feature:

Current Behavior:

Expected Behavior:

Additional Context:

Before implementation:

1. Inspect how the feature currently manages state.
2. Read `docs/02_architecture.md`.
3. Read `docs/08_decisions.md`.
4. Determine which state is local and which state needs to be shared.
5. Search for existing state-related patterns.
6. Check whether a state-management decision has already been approved.

Important:

The project's state-management decision is currently deferred.

Do not introduce Riverpod, Provider, Bloc, GetX, or another project-wide state-management solution unless the developer has explicitly approved it.

Until a final state-management decision is made:

- Keep state responsibilities clear.
- Prefer simple local state where appropriate.
- Avoid unnecessary global state.
- Keep UI separate from business logic.
- Avoid designing the feature around an unapproved state-management framework.
- Keep the implementation easy to migrate once the project decision is made.

If the requested feature genuinely requires a project-wide state-management decision, stop and discuss the available approaches before implementing it.

Otherwise, implement only the state handling required for the current task.
```

---

# 09 — Local Storage Task

Use when implementing local persistence in the Flutter application.

```text
I want to implement local storage for a Foody feature.

Feature:

Data to Store:

Expected Behavior:

Additional Context:

Before implementation:

1. Inspect existing local-storage usage.
2. Read `docs/08_decisions.md`.
3. Search the project for existing storage utilities or services.
4. Determine whether the data is appropriate for local storage.
5. Check whether the stored data contains sensitive information.
6. Check whether the stored data needs expiration, clearing, or migration.

The approved local-storage solution for the project is SharedPreferences.

Do not introduce another local-storage package unless the developer explicitly requests it or an approved project decision changes.

Do not store sensitive credentials or secrets in SharedPreferences.

Before implementation, identify:

- What will be stored.
- Why it belongs in local storage.
- Where the storage logic should live.
- How the data will be read and updated.
- Any relevant limitations.

Then implement the smallest appropriate solution.
```

---

# 10 — Code Review

Use when reviewing existing code without immediately modifying it.

```text
Review the relevant Foody implementation.

Target:

Review Goals:

Additional Context:

Do not modify the code unless explicitly requested.

Inspect:

- Architecture.
- Readability.
- Maintainability.
- Reusability.
- Performance.
- Error handling.
- State handling.
- Design System usage.
- Security concerns.
- Technical debt.
- Phase compliance.
- Project decision compliance.

Use the existing Foody documentation as the review standard.

Do not recommend changes merely because you would personally structure the code differently.

Report:

1. Critical problems.
2. Important improvements.
3. Minor improvements.
4. Existing strengths.
5. Recommended changes.

Prioritize meaningful issues over stylistic preferences.
```

---

# 11 — Architecture Review

Use when evaluating an architectural decision.

```text
I want to review the architecture of a Foody feature or project area.

Target:

Current Approach:

Problem:

Additional Context:

Before recommending changes:

1. Read `docs/02_architecture.md`.
2. Read relevant project decisions.
3. Inspect the current implementation.
4. Identify dependencies and affected features.
5. Consider maintainability, scalability, complexity, and migration cost.
6. Check whether the proposed change affects the current development phase.

Compare the viable approaches.

For each approach explain:

- Advantages.
- Disadvantages.
- Complexity.
- Maintainability.
- Performance considerations.
- Effect on the existing architecture.
- Migration cost.
- Effect on future development.

Recommend an approach when appropriate.

Do not implement a significant architectural change until the developer approves it.
```

---

# 12 — Add or Change a Project Decision

Use when a significant project-level decision is required.

```text
I believe the Foody project needs a new or changed project decision.

Topic:

Current Situation:

Problem:

Additional Context:

Before changing the decision:

1. Read `docs/08_decisions.md`.
2. Check for related decisions.
3. Inspect the affected implementation.
4. Identify viable alternatives.
5. Explain the trade-offs.
6. Determine the effect on the current and future phases.

Do not immediately modify the project decision.

First provide:

- Current decision, if one exists.
- Problem with the current approach.
- Available alternatives.
- Recommended approach.
- Expected impact.
- Migration or implementation implications.

Wait for developer approval.

After approval, update `docs/08_decisions.md` using the established decision format.
```

---

# 13 — Phase Planning

Use when preparing a new development phase.

```text
We are preparing a Foody development phase.

Phase:

Goal:

Additional Context:

Before planning:

1. Read `docs/07_future_phases.md`.
2. Read `docs/08_decisions.md`.
3. Review the architecture.
4. Review the Design System.
5. Review existing components.
6. Inspect the current project state.
7. Review the previous phase and its Definition of Done.
8. Identify dependencies from previous phases.

Do not assume that the future-phase description is a complete implementation specification.

Help define:

- Phase scope.
- Included features.
- Explicitly excluded features.
- Required screens.
- Required components.
- Backend dependencies.
- Data requirements.
- Navigation requirements.
- Loading/error/empty states.
- Definition of Done.

Identify missing or conflicting requirements.

Do not implement the phase yet.

First validate and organize the scope with the developer.

Once approved, update `docs/06_current_phase.md`.
```

---

# 14 — Phase Completion Review

Use before marking a development phase as completed.

```text
Review the current Foody development phase before marking it as completed.

Read:

- `docs/06_current_phase.md`
- `docs/07_future_phases.md`
- `docs/08_decisions.md`

Also inspect the actual project implementation.

Review:

- Definition of Done.
- Implemented requirements.
- Missing requirements.
- Known bugs.
- UI consistency.
- Architecture consistency.
- API integration.
- Error handling.
- Loading states.
- Empty states.
- Code quality.
- Documentation consistency.

Do not modify code automatically.

Report:

1. Completed requirements.
2. Missing requirements.
3. Known issues.
4. Technical debt.
5. Documentation inconsistencies.
6. Recommended follow-up work.
7. Whether the phase is ready to be marked as completed.

Do not mark the phase as completed without developer confirmation.
```

---

# 15 — Explain Existing Code

Use when the developer wants to understand an implementation.

```text
Explain the relevant Foody implementation to me.

Target:

Additional Context:

I want to understand the implementation before modifying it.

Prioritize explanation over code changes.

Explain:

1. What the code is responsible for.
2. How the main classes/widgets interact.
3. How data flows through the implementation.
4. Why the current structure fits the project architecture.
5. Which Flutter/Dart concepts are being used.
6. What I should understand before modifying it.
7. Potential problems or improvements, if any.

Use the actual project implementation as the primary source.

Do not modify the code unless I explicitly ask you to.
```

---

# 16 — Performance Review

Use when investigating a potential performance issue.

```text
Review the performance of the relevant Foody implementation.

Target:

Observed Problem:

Additional Context:

Before optimizing:

1. Inspect the implementation.
2. Identify the actual source of the performance concern.
3. Check rebuild behavior.
4. Check network requests.
5. Check image/resource loading.
6. Check list rendering.
7. Check expensive operations.
8. Determine whether the concern is measurable or theoretical.

Do not optimize prematurely.

Explain:

- Root cause.
- Evidence.
- Proposed optimization.
- Expected benefit.
- Complexity introduced.
- Potential side effects.

Only implement an optimization when it provides meaningful value.
```

---

# 17 — Final Implementation Review

Use after completing a significant task.

```text
Perform a final review of the Foody task that was just implemented.

Task:

Additional Context:

Review the final implementation against:

- Current phase requirements.
- Architecture.
- Design System.
- Components.
- Coding Guidelines.
- Project Decisions.

Inspect the actual changes and check for:

- Incorrect behavior.
- Missing states.
- Duplicate code.
- Unnecessary files.
- Hardcoded values.
- Incorrect navigation.
- State-handling issues.
- API integration issues.
- Security concerns.
- Potential regressions.
- Unnecessary complexity.
- Future-phase functionality accidentally introduced.

Do not make changes automatically.

Report findings as:

Critical
Important
Minor
Optional

Then recommend whether the implementation is ready to continue.

Do not claim that something was tested unless it was actually verified.
```

---

# Template Usage Rules

When using these templates:

* Treat fields as **optional context**, not mandatory form fields.
* Do not manually repeat information already available in the project.
* Allow the Agent to inspect the repository and documentation.
* Let the Agent determine the current phase from `docs/06_current_phase.md`.
* Let the Agent determine relevant architecture and project decisions from the documentation.
* Provide explicit information only when it cannot be safely determined from the project.
* Provide Figma references when the Agent cannot access the relevant design otherwise.
* Provide API contracts when they are not available in the repository.
* Provide exact error messages when debugging information is not available elsewhere.
* Do not invent missing requirements.
* Do not force the Agent to ask for information that can be safely inferred.
* Use the smallest template that provides sufficient task context.

Templates are **starting points, not forms that must be completed**.

The Agent may request additional information when the task requires it.

---

# Relationship With Agent Documentation

The templates do not replace the Agent rules.

The Agent must continue to follow:

```text
agents/01_agent_overview.md
        ↓
agents/02_agent_workflow.md
        ↓
agents/03_agent_rules.md
        ↓
agents/04_prompt_templates.md
```

The templates define how common tasks are communicated.

The Agent Overview defines the Agent's role and project context.

The Workflow defines how the Agent approaches tasks.

The Rules define mandatory behavior.

The templates provide task-specific starting instructions.

---

# Final Principle

> **Provide the Agent with what it cannot know. Let it discover what the project already knows. Ask only when an important decision cannot be safely determined.**
