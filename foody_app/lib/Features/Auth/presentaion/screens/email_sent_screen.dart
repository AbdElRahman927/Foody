import 'package:flutter/material.dart';
import 'package:foody_app/core/theme/app_colors.dart';
import 'package:foody_app/core/theme/app_spacing.dart';
import 'package:foody_app/features/auth/presentaion/screens/forget_password.dart';
import 'package:foody_app/features/auth/presentaion/screens/login_screen.dart';

class EmailSentScreen extends StatefulWidget {
  const EmailSentScreen({super.key, required this.email});
  final String email;

  @override
  State<EmailSentScreen> createState() => _EmailSentScreenState();
}

class _EmailSentScreenState extends State<EmailSentScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Container(
          padding: EdgeInsets.symmetric(horizontal: AppSpacing.s24),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Container(
                width: 100,
                height: 100,
                decoration: BoxDecoration(
                  color: AppColors.successGreen.withValues(alpha: 0.15),
                  borderRadius: BorderRadius.circular(300),
                ),
                child: Container(
                  margin: EdgeInsets.all(24),
                  decoration: BoxDecoration(
                    color: AppColors.successGreen,
                    borderRadius: BorderRadius.circular(300),
                  ),
                  child: Icon(
                    Icons.check,
                    size: 40,
                    color: AppColors.surfaceWhite,
                  ),
                ),
              ),
              SizedBox(height: AppSpacing.s24),
              Text(
                "Email Sent",
                style: Theme.of(context).textTheme.titleLarge?.copyWith(
                  color: AppColors.textPrimaryDarkGrey,
                ),
              ),
              SizedBox(height: AppSpacing.s8),
              Text(
                "We've sent a password reset link to ${widget.email}. Check your inbox.",
                textAlign: TextAlign.center,
                style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                  color: AppColors.textSecondaryLightGrey,
                ),
              ),

              SizedBox(height: AppSpacing.s24),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (context) => const LoginScreen(),
                      ),
                    );
                  },
                  child: const Text('Back to Login'),
                ),
              ),

              TextButton(
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => const ForgetPasswordScreen(),
                    ),
                  );
                },
                child: Text(
                  'Resend Email',
                  style: TextStyle(
                    color: AppColors.primaryWarmOrange,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
