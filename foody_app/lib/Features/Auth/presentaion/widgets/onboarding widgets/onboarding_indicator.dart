import 'package:flutter/material.dart';
import 'package:foody_app/core/theme/app_colors.dart';

class OnboardingIndicator extends StatelessWidget {
  final int currentIndex;
  final int itemCount;

  const OnboardingIndicator({
    super.key,
    required this.currentIndex,
    required this.itemCount,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: List.generate(itemCount, (index) {
        final isActive = index == currentIndex;

        return AnimatedContainer(
          duration: const Duration(milliseconds: 250),
          curve: Curves.easeInOut,
          margin: const EdgeInsets.symmetric(horizontal: 4),
          width: isActive ? 28 : 12,
          height: 12,
          decoration: BoxDecoration(
            color: isActive
                ? AppColors.primaryWarmOrange
                : AppColors.textSecondaryLightGrey,
            borderRadius: BorderRadius.circular(100),
          ),
        );
      }),
    );
  }
}
