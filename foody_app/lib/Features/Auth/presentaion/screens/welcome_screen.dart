import 'package:flutter/material.dart';
import 'package:foody_app/core/constants/assets_constants.dart';
import 'package:foody_app/core/theme/app_colors.dart';
import 'package:foody_app/core/theme/app_raduis.dart';
import 'package:foody_app/core/theme/app_spacing.dart';
import 'package:foody_app/features/auth/presentaion/screens/login_screen.dart';
import 'package:foody_app/features/auth/presentaion/screens/register_screen.dart';

class WelcomeScreen extends StatefulWidget {
  const WelcomeScreen({super.key});

  @override
  State<WelcomeScreen> createState() => _WelcomeScreenState();
}

class _WelcomeScreenState extends State<WelcomeScreen> {
  void navigateToLogin() {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => const LoginScreen()),
    );
  }

  void navigateToRegister() {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => const RegisterScreen()),
    );
  }

  @override
  Widget build(BuildContext context) {
    double width = MediaQuery.of(context).size.width;
    double height = MediaQuery.of(context).size.height;
    return Scaffold(
      body: Container(
        width: width,
        height: height,
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
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Image.asset(AssetsConstants.mainLogo, width: 200, height: 200),

            Text(
              'Your guide to the best restaurants in your city.',
              style: Theme.of(context).textTheme.headlineMedium?.copyWith(
                color: AppColors.textPrimaryDarkGrey,
              ),
              textAlign: TextAlign.center,
            ),
            SizedBox(height: AppSpacing.s24),

            SizedBox(
              width: width * 0.8,
              height: 50,
              child: ElevatedButton(
                onPressed: navigateToLogin,
                style: ElevatedButton.styleFrom(
                  backgroundColor: AppColors.primaryWarmOrange,
                  foregroundColor: AppColors.surfaceWhite,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(AppRaduis.medium),
                  ),
                ),
                child: Text('Login'),
              ),
            ),
            SizedBox(height: AppSpacing.s24),
            SizedBox(
              width: width * 0.8,
              height: 50,
              child: ElevatedButton(
                onPressed: navigateToRegister,
                child: Text('Create Account'),
                style: ElevatedButton.styleFrom(
                  backgroundColor: AppColors.backgroundOffWhite,
                  foregroundColor: AppColors.primaryWarmOrange,
                  side: BorderSide(color: AppColors.primaryWarmOrange),
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(AppRaduis.medium),
                  ),
                ),
              ),
            ),
            SizedBox(height: AppSpacing.s24),
            
            
            Text.rich(
              textAlign: TextAlign.center,
              TextSpan(
                text: 'By continuing, you agree to our ',
                style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                  color: AppColors.textSecondaryLightGrey,
                ),
                children: [
                  
                  TextSpan(
                    text: 'Terms of Use ',
                    style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                      color: AppColors.primaryWarmOrange,
                    ),
                  ),
                  TextSpan(
                    text: 'and ',
                    style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                      color: AppColors.textSecondaryLightGrey,
                    ),
                  ),
                  TextSpan(
                    text: 'Privacy Policy',
                    style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                      color: AppColors.primaryWarmOrange,
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
