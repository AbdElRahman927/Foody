
import 'package:flutter/material.dart';
import 'package:foody_app/core/theme/app_colors.dart';
import 'package:foody_app/core/theme/app_raduis.dart';

class GenderOption extends StatelessWidget {
  const GenderOption({super.key, 
    required this.label,
    required this.value,
    required this.selectedValue,
    required this.onSelected,
  });

  final String label;
  final String value;
  final String? selectedValue;
  final ValueChanged<String> onSelected;

  @override
  Widget build(BuildContext context) {
    final isSelected = selectedValue == value;

    return InkWell(
      onTap: () => onSelected(value),
      borderRadius: BorderRadius.circular(AppRaduis.medium),
      child: Container(
        height: 44,
        padding: const EdgeInsets.symmetric(horizontal: 12),
        decoration: BoxDecoration(
          color: isSelected
              ? AppColors.primaryWarmOrange.withValues(alpha: 0.08)
              : AppColors.surfaceWhite,
          borderRadius: BorderRadius.circular(AppRaduis.medium),
          border: Border.all(
            color: isSelected
                ? AppColors.primaryWarmOrange
                : AppColors.border,
          ),
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Container(
              width: 18,
              height: 18,
              decoration: BoxDecoration(
                shape: BoxShape.circle,
                border: Border.all(
                  color: isSelected
                      ? AppColors.primaryWarmOrange
                      : AppColors.textSecondaryLightGrey,
                  width: 1.5,
                ),
              ),
              child: isSelected
                  ? Center(
                      child: Container(
                        width: 8,
                        height: 8,
                        decoration: const BoxDecoration(
                          shape: BoxShape.circle,
                          color: AppColors.primaryWarmOrange,
                        ),
                      ),
                    )
                  : null,
            ),

            const SizedBox(width: 8),

            Flexible(
              child: Text(
                label,
                overflow: TextOverflow.ellipsis,
                style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                  color: isSelected
                      ? AppColors.primaryWarmOrange
                      : AppColors.textPrimaryDarkGrey,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}