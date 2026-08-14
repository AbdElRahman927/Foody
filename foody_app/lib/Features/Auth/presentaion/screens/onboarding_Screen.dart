import 'package:flutter/material.dart';
import 'package:foody_app/core/theme/app_colors.dart';
import 'package:foody_app/core/theme/app_spacing.dart';
import 'package:foody_app/features/auth/data/onBoarding/onboarding_data.dart';
import 'package:foody_app/features/auth/presentaion/screens/welcome_screen.dart';
import 'package:foody_app/features/auth/presentaion/widgets/onboarding%20widgets/onboarding_page.dart';

class OnboardingScreen extends StatefulWidget {
  const OnboardingScreen({super.key});

  @override
  State<OnboardingScreen> createState() => _OnboardingScreenState();
}

class _OnboardingScreenState extends State<OnboardingScreen> {
  int _currentPage = 0;

  @override
  void dispose() {
    super.dispose();
  }

  void _nextPage() {
    if (_currentPage < onboardingPages.length - 1) {
      setState(() {
        _currentPage++;
      });
    } else {
      Navigator.push(
        context,
        MaterialPageRoute(builder: (context) => const WelcomeScreen()),
      );
    }
  }

  void _previousPage() {
    if (_currentPage > 0) {
      setState(() {
        _currentPage--;
      });
    } else {}
  }

  void _skipOnboarding() {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => const WelcomeScreen()),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        width: double.infinity,
        decoration: BoxDecoration(
          gradient: LinearGradient(
            begin: Alignment.topCenter,
            end: Alignment.bottomCenter,
            colors: [
              AppColors.backgroundOffWhite,
              AppColors.backgroundOffWhite,
            ],
          ),
        ),
        child: Padding(
          padding: EdgeInsets.all(AppSpacing.s24),
          child: Column(
            children: [
              // Skip
              Align(
                alignment: Alignment.centerRight,
                child: TextButton(
                  onPressed: _skipOnboarding,
                  child: Text(
                    'Skip',
                    style: Theme.of(context).textTheme.labelLarge?.copyWith(
                      color: AppColors.primaryWarmOrange,
                    ),
                  ),
                ),
              ),

              // Pages
              Expanded(
                child: OnboardingPage(
                  data: onboardingPages[_currentPage],
                  onNext: _nextPage,

                  onPrevious: _previousPage,
                  isLastPage: _currentPage == onboardingPages.length - 1,
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
