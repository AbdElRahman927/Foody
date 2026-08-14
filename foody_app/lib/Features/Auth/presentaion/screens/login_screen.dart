import 'package:flutter/material.dart';
import 'package:foody_app/core/theme/app_colors.dart';
import 'package:foody_app/core/theme/app_raduis.dart';
import 'package:foody_app/core/theme/app_spacing.dart';
import 'package:foody_app/features/auth/presentaion/screens/forget_password.dart';
import 'package:foody_app/features/auth/presentaion/screens/register_screen.dart';
import 'package:foody_app/features/auth/presentaion/screens/test_homescreen.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({super.key});

  @override
  State<LoginScreen> createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final _formKey = GlobalKey<FormState>();

  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();

  bool isLoading = false;

  @override
  void dispose() {
    _emailController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  bool obscureText = true;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        width: double.infinity,
        padding: EdgeInsets.all(AppSpacing.s24),
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
              Text(
                "Welcome Back 👋",
                style: Theme.of(context).textTheme.titleLarge?.copyWith(
                  color: AppColors.textPrimaryDarkGrey,
                ),
              ),
              SizedBox(height: AppSpacing.s4),
              Text(
                "Sign in to continue to Foody",
                style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                  color: AppColors.textSecondaryLightGrey,
                ),
              ),

              SizedBox(height: AppSpacing.s40),
              Form(
                key: _formKey,
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      "Email Address",
                      style: Theme.of(context).textTheme.labelLarge?.copyWith(
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
                              hintText: 'Email Address',
                            ),
                          );
                        },
                      ),
                    ),
                    SizedBox(height: AppSpacing.s32),

                    Text(
                      "Password",
                      style: Theme.of(context).textTheme.labelLarge?.copyWith(
                        color: AppColors.textPrimaryDarkGrey,
                      ),
                    ),
                    SizedBox(height: AppSpacing.s12),

                    Focus(
                      child: Builder(
                        builder: (context) {
                          final hasFocus = Focus.of(context).hasFocus;

                          return TextFormField(
                            controller: _passwordController,
                            obscureText: obscureText,
                            validator: (value) {
                              if (value == null || value.isEmpty) {
                                return 'Please enter your password';
                              }

                              if (value.length < 6) {
                                return 'Password must be at least 6 characters';
                              }

                              return null;
                            },
                            decoration: InputDecoration(
                              prefixIcon: Icon(
                                Icons.lock_outlined,
                                color: hasFocus
                                    ? AppColors.primaryWarmOrange
                                    : AppColors.textSecondaryLightGrey,
                              ),
                              suffixIcon: IconButton(
                                icon: Icon(
                                  color: hasFocus
                                      ? AppColors.primaryWarmOrange
                                      : AppColors.textSecondaryLightGrey,
                                  obscureText
                                      ? Icons.visibility_off_outlined
                                      : Icons.visibility_outlined,
                                ),
                                onPressed: () {
                                  setState(() {
                                    obscureText = !obscureText;
                                  });
                                },
                              ),
                              hintText: 'Password',

                              border: OutlineInputBorder(
                                borderRadius: BorderRadius.circular(
                                  AppRaduis.medium,
                                ),
                              ),
                            ),
                          );
                        },
                      ),
                    ),
                  ],
                ),
              ),

              SizedBox(height: AppSpacing.s24),
              Row(
                mainAxisAlignment: MainAxisAlignment.end,
                children: [
                  InkWell(
                    onTap: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => const ForgetPasswordScreen(),
                        ),
                      );
                    },
                    child: Text(
                      "Forget Password?",
                      style: Theme.of(context).textTheme.labelLarge?.copyWith(
                        color: AppColors.primaryWarmOrange,
                      ),
                    ),
                  ),
                ],
              ),

              SizedBox(height: AppSpacing.s40),
              SizedBox(
                width: double.infinity,
                height: 50,
                child: ElevatedButton(
                  onPressed: () async {
                    if (!_formKey.currentState!.validate()) {
                      return;
                    }

                    setState(() {
                      isLoading = true;
                    });

                    try {
                      // هنا هتعمل login
                      //
                      // await authService.login(
                      //   _emailController.text.trim(),
                      //   _passwordController.text,
                      // );

                      Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => HomeScreen()),
                      );
                    } catch (e) {
                      // Login/API error
                      ScaffoldMessenger.of(context).showSnackBar(
                        const SnackBar(
                          content: Text('Invalid email or password'),
                        ),
                      );
                    } finally {
                      if (mounted) {
                        setState(() {
                          isLoading = false;
                        });
                      }
                    }
                  },
                  child: isLoading
                      ? const SizedBox(
                          width: 20,
                          height: 20,
                          child: CircularProgressIndicator(strokeWidth: 2),
                        )
                      : const Text('Login'),
                ),
              ),
              SizedBox(height: AppSpacing.s24),

              Row(
                children: [
                  Expanded(
                    child: Divider(
                      color: AppColors.textSecondaryLightGrey,
                      thickness: 2,
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.symmetric(horizontal: AppSpacing.s12),
                    child: Text(
                      "OR",
                      style: Theme.of(context).textTheme.labelLarge?.copyWith(
                        color: AppColors.textSecondaryLightGrey,
                      ),
                    ),
                  ),
                  Expanded(
                    child: Divider(
                      color: AppColors.textSecondaryLightGrey,
                      thickness: 2,
                    ),
                  ),
                ],
              ),
              SizedBox(height: AppSpacing.s24),

              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(
                    "Don't have an account? ",
                    style: Theme.of(context).textTheme.labelLarge?.copyWith(
                      color: AppColors.textSecondaryLightGrey,
                    ),
                  ),
                  InkWell(
                    onTap: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => const RegisterScreen(),
                        ),
                      );
                    },
                    child: Text(
                      "Sign Up",
                      style: Theme.of(context).textTheme.labelLarge?.copyWith(
                        color: AppColors.primaryWarmOrange,
                      ),
                    ),
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}
