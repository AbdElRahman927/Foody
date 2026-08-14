import 'package:flutter/material.dart';
import 'package:foody_app/core/theme/app_colors.dart';
import 'package:foody_app/core/theme/app_raduis.dart';
import 'package:foody_app/core/theme/app_spacing.dart';
import 'package:foody_app/features/auth/presentaion/screens/email_sent_screen.dart';

class ForgetPasswordScreen extends StatefulWidget {
  const ForgetPasswordScreen({super.key});

  @override
  State<ForgetPasswordScreen> createState() => _ForgetPasswordScreenState();
}

class _ForgetPasswordScreenState extends State<ForgetPasswordScreen> {
  final _formKey = GlobalKey<FormState>();
  final _emailController = TextEditingController();

  bool isEmailSend = false;

  @override
  void dispose() {
    _emailController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return isEmailSend
        ? EmailSentScreen(email: _emailController.text)
        : Scaffold(
            body: Container(
              padding: EdgeInsets.symmetric(horizontal: AppSpacing.s24),
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
              child: SafeArea(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    SizedBox(height: AppSpacing.s24),
                    Container(
                      width: 48,
                      height: 48,
                      decoration: BoxDecoration(
                        color: AppColors.surfaceWhite,
                        borderRadius: BorderRadius.circular(AppRaduis.medium),
                        border: Border.all(color: AppColors.border),
                      ),
                      child: IconButton(
                        icon: Icon(
                          Icons.arrow_back_ios_new,
                          color: AppColors.textSecondaryLightGrey,
                        ),
                        onPressed: () {
                          Navigator.pop(context);
                        },
                      ),
                    ),

                    SizedBox(height: AppSpacing.s32),
                    Container(
                      width: 72,
                      height: 72,
                      decoration: BoxDecoration(
                        color: AppColors.primaryWarmOrange.withValues(
                          alpha: 0.08,
                        ),
                        borderRadius: BorderRadius.circular(AppRaduis.medium),
                        border: Border.all(
                          color: AppColors.primaryWarmOrange,
                          width: 0.9,
                        ),
                      ),
                      child: Icon(
                        Icons.email_outlined,
                        size: 40,
                        color: AppColors.primaryWarmOrange,
                      ),
                    ),

                    SizedBox(height: AppSpacing.s24),
                    Text(
                      "Forgot Password?",
                      style: Theme.of(context).textTheme.titleLarge?.copyWith(
                        color: AppColors.textPrimaryDarkGrey,
                      ),
                    ),
                    SizedBox(height: AppSpacing.s4),
                    Text(
                      "No worries! Enter your registered email and we'll send you a reset link.",
                      style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                        color: AppColors.textSecondaryLightGrey,
                      ),
                    ),

                    SizedBox(height: AppSpacing.s24),
                    Form(
                      key: _formKey,
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text(
                            "Email Address",
                            style: Theme.of(context).textTheme.labelLarge
                                ?.copyWith(
                                  color: AppColors.textPrimaryDarkGrey,
                                ),
                          ),
                          SizedBox(height: AppSpacing.s12),

                          Focus(
                            child: Builder(
                              builder: (context) {
                                final hasFocus = Focus.of(context).hasFocus;

                                return TextFormField(
                                  controller: _emailController,
                                  validator: (value) {
                                    if (value == null || value.trim().isEmpty) {
                                      return 'Please enter your email';
                                    }

                                    final emailRegex = RegExp(
                                      r'^[^@\s]+@[^@\s]+\.[^@\s]+$',
                                    );

                                    if (!emailRegex.hasMatch(value.trim())) {
                                      return 'Please enter a valid email';
                                    }

                                    return null;
                                  },
                                  decoration: InputDecoration(
                                    prefixIcon: Icon(
                                      Icons.email_outlined,
                                      color: hasFocus
                                          ? AppColors.primaryWarmOrange
                                          : AppColors.textSecondaryLightGrey,
                                    ),
                                    hintText: 'Email',
                                    border: OutlineInputBorder(
                                      borderRadius: BorderRadius.circular(
                                        AppRaduis.medium,
                                      ),
                                      borderSide: BorderSide(
                                        color: hasFocus
                                            ? AppColors.primaryWarmOrange
                                            : AppColors.border,
                                      ),
                                    ),
                                  ),
                                );
                              },
                            ),
                          ),
                          SizedBox(height: AppSpacing.s24),
                        ],
                      ),
                    ),

                    SizedBox(
                      width: double.infinity,
                      height: 56,
                      child: ElevatedButton(
                        onPressed: () {
                          if (_formKey.currentState!.validate()) {
                            setState(() {
                              isEmailSend = true;
                            });
                          }
                        },
                        child: const Text('Send Reset Link'),
                      ),
                    ),
                  ],
                ),
              ),
            ),
          );
  }
}
