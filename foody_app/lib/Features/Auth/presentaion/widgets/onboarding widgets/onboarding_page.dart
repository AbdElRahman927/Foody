import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';

import 'package:foody_app/core/theme/app_colors.dart';
import 'package:foody_app/core/theme/app_raduis.dart';
import 'package:foody_app/core/theme/app_spacing.dart';
import 'package:foody_app/features/auth/data/onBoarding/onboarding_data.dart';
import 'package:foody_app/features/auth/data/onBoarding/onboarding_model.dart';
import 'package:foody_app/features/auth/presentaion/widgets/onboarding%20widgets/onboarding_indicator.dart';

class OnboardingPage extends StatelessWidget {
  final OnboardingModel data;
  final VoidCallback onNext;
  final VoidCallback onPrevious;
  final bool isLastPage;

  const OnboardingPage({
    super.key,
    required this.data,
    required this.onNext,
    required this.onPrevious,
    required this.isLastPage,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.spaceAround,
      children: [
        // Image
        Container(
          width: 300,
          height: 300,
          child: SvgPicture.asset(data.photo),
        ),

        // Text + Button
        Column(
          children: [
            Text(
              data.title1,
              textAlign: TextAlign.center,
              style: Theme.of(context).textTheme.titleLarge?.copyWith(
                color: AppColors.textPrimaryDarkGrey,
              ),
            ),

            const SizedBox(height: AppSpacing.s16),

            Text(
              data.title2,
              textAlign: TextAlign.center,
              style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                color: AppColors.textSecondaryLightGrey,
              ),
            ),

            const SizedBox(height: AppSpacing.s32),
            OnboardingIndicator(
              currentIndex: data.index,
              itemCount: onboardingPages.length,
            ),

            const SizedBox(height: AppSpacing.s32),

            Row(
              children: [
                if (data.index > 0) ...[
                  Container(
                    padding: EdgeInsets.all(AppSpacing.s8),
                    width: 52,
                    height: 52,
                    decoration: BoxDecoration(
                      border: Border.all(
                        color: AppColors.textSecondaryLightGrey,
                      ),
                      borderRadius: BorderRadius.circular(AppRaduis.medium),
                      color: AppColors.surfaceWhite,
                    ),
                    child: TextButton(
                      onPressed: onPrevious,
                      style: TextButton.styleFrom(
                        padding: EdgeInsets.zero,
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(AppRaduis.medium),
                        ),
                      ),
                      child: Icon(
                        Icons.arrow_back_ios_new,
                        color: AppColors.textSecondaryLightGrey,
                      ),
                    ),
                  ),
                  const SizedBox(width: AppSpacing.s12),
                ],

                Expanded(
                  child: SizedBox(
                    height: 52,
                    child: ElevatedButton(
                      onPressed: onNext,
                      child: Text(
                        isLastPage ? 'Get Started' : 'Next',
                        style: Theme.of(context).textTheme.labelLarge?.copyWith(
                          color: AppColors.surfaceWhite,
                        ),
                      ),
                    ),
                  ),
                ),
              ],
            ),
          ],
        ),
      ],
    );
  }
}
