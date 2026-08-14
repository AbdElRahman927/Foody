import 'package:flutter/material.dart';
import 'package:foody_app/core/theme/app_colors.dart';
import 'package:foody_app/core/theme/app_spacing.dart';
import 'package:foody_app/features/auth/presentaion/widgets/Register%20widgets/gender_option.dart';

class GenderSelector extends StatelessWidget {
  const GenderSelector({super.key, required this.onChanged, this.validator});

  final ValueChanged<String?> onChanged;
  final FormFieldValidator<String>? validator;

  @override
  Widget build(BuildContext context) {
    return FormField<String>(
      validator: validator,
      builder: (FormFieldState<String> state) {
        return Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              children: [
                Expanded(
                  child: GenderOption(
                    label: 'Male',
                    value: 'Male',
                    selectedValue: state.value,
                    onSelected: (value) {
                      state.didChange(value);
                      onChanged(value);
                    },
                  ),
                ),
                SizedBox(width: AppSpacing.s12),
                Expanded(
                  child: GenderOption(
                    label: 'Female',
                    value: 'Female',
                    selectedValue: state.value,
                    onSelected: (value) {
                      state.didChange(value);
                      onChanged(value);
                    },
                  ),
                ),
                SizedBox(width: AppSpacing.s12),
                Expanded(
                  child: GenderOption(
                    label: 'Other',
                    value: 'Other',
                    selectedValue: state.value,
                    onSelected: (value) {
                      state.didChange(value);
                      onChanged(value);
                    },
                  ),
                ),
              ],
            ),

            if (state.hasError) ...[
              SizedBox(height: AppSpacing.s8),
              Row(
                children: [
                  const Icon(Icons.error, size: 14, color: AppColors.errorRed),
                  SizedBox(width: AppSpacing.s4),
                  Text(
                    state.errorText!,
                    style: Theme.of(
                      context,
                    ).textTheme.bodySmall?.copyWith(color: AppColors.errorRed),
                  ),
                ],
              ),
            ],
          ],
        );
      },
    );
  }
}
