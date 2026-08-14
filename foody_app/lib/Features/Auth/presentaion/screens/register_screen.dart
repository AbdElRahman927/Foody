import 'package:flutter/material.dart';
import 'package:foody_app/core/theme/app_colors.dart';
import 'package:foody_app/core/theme/app_raduis.dart';
import 'package:foody_app/core/theme/app_spacing.dart';
import 'package:foody_app/features/auth/presentaion/screens/login_screen.dart';
import 'package:foody_app/features/auth/presentaion/widgets/Register%20widgets/gender_selector.dart';

class RegisterScreen extends StatefulWidget {
  const RegisterScreen({super.key});

  @override
  State<RegisterScreen> createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> {
  final _formKey = GlobalKey<FormState>();

  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  final _confirmPasswordController = TextEditingController();
  final _nameController = TextEditingController();
  String gender = '';

  bool isLoading = false;

  @override
  void dispose() {
    _emailController.dispose();
    _passwordController.dispose();
    _confirmPasswordController.dispose();
    _nameController.dispose();
    super.dispose();
  }

  bool obscureText = true;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: ListView(
        children: [
          Container(
            width: double.infinity,
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
                  Text(
                    "Create Account ✨",
                    style: Theme.of(context).textTheme.titleLarge?.copyWith(
                      color: AppColors.textPrimaryDarkGrey,
                    ),
                  ),
                  SizedBox(height: AppSpacing.s4),
                  Text(
                    "Join Foody and discover amazing restaurants",
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
                          "Full Name",
                          style: Theme.of(context).textTheme.labelLarge
                              ?.copyWith(color: AppColors.textPrimaryDarkGrey),
                        ),
                        SizedBox(height: AppSpacing.s12),

                        Focus(
                          child: Builder(
                            builder: (context) {
                              final hasFocus = Focus.of(context).hasFocus;

                              return TextFormField(
                                controller: _nameController,
                                validator: (value) {
                                  if (value == null || value.trim().isEmpty) {
                                    return 'Please enter your name';
                                  }

                                  if (value.length < 3) {
                                    return 'Name must be at least 3 characters';
                                  }

                                  return null;
                                },
                                decoration: InputDecoration(
                                  prefixIcon: Icon(
                                    Icons.person_outline,
                                    color: hasFocus
                                        ? AppColors.primaryWarmOrange
                                        : AppColors.textSecondaryLightGrey,
                                  ),
                                  hintText: 'Full Name',
                                ),
                              );
                            },
                          ),
                        ),
                        SizedBox(height: AppSpacing.s24),

                        Text(
                          "Email Address",
                          style: Theme.of(context).textTheme.labelLarge
                              ?.copyWith(color: AppColors.textPrimaryDarkGrey),
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
                        SizedBox(height: AppSpacing.s24),

                        Text(
                          "Gender",
                          style: Theme.of(context).textTheme.labelLarge
                              ?.copyWith(color: AppColors.textPrimaryDarkGrey),
                        ),
                        SizedBox(height: AppSpacing.s12),

                        GenderSelector(
                          onChanged: (value) {
                            setState(() {
                              gender = value!;
                            });
                          },
                          validator: (value) {
                            if (value == null || value.trim().isEmpty) {
                              return 'Please select your gender';
                            }
                            return null;
                          },
                        ),

                        Text(
                          "Password",
                          style: Theme.of(context).textTheme.labelLarge
                              ?.copyWith(color: AppColors.textPrimaryDarkGrey),
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

                        SizedBox(height: AppSpacing.s24),

                        Text(
                          "Confirm Password",
                          style: Theme.of(context).textTheme.labelLarge
                              ?.copyWith(color: AppColors.textPrimaryDarkGrey),
                        ),
                        SizedBox(height: AppSpacing.s12),

                        Focus(
                          child: Builder(
                            builder: (context) {
                              final hasFocus = Focus.of(context).hasFocus;

                              return TextFormField(
                                controller: _confirmPasswordController,
                                obscureText: obscureText,
                                validator: (value) {
                                  if (value == null || value.trim().isEmpty) {
                                    return 'Please enter your confirm password';
                                  }

                                  if (value.trim().length < 6) {
                                    return 'Password must be at least 6 characters';
                                  }
                                  if (value.trim() !=
                                      _passwordController.text.trim()) {
                                    return 'Passwords do not match';
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
                                  hintText: 'Re-enter your password',

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
                          // TODO: implement register
                          // await authService.register(
                          //   _emailController.text.trim(),
                          //   _passwordController.text,
                          // );
                          return showDialog(
                            context: context,
                            builder: (context) {
                              return AlertDialog(
                                title: Column(
                                  crossAxisAlignment: CrossAxisAlignment.center,
                                  children: [
                                    Container(
                                      width: 100,
                                      height: 100,
                                      decoration: BoxDecoration(
                                        color: AppColors.successGreen
                                            .withValues(alpha: 0.15),
                                        borderRadius: BorderRadius.circular(
                                          300,
                                        ),
                                      ),
                                      child: Container(
                                        margin: EdgeInsets.all(24),
                                        decoration: BoxDecoration(
                                          color: AppColors.successGreen,
                                          borderRadius: BorderRadius.circular(
                                            300,
                                          ),
                                        ),
                                        child: Icon(
                                          Icons.check,
                                          size: 40,
                                          color: AppColors.surfaceWhite,
                                        ),
                                      ),
                                    ),
                                    SizedBox(height: AppSpacing.s12),
                                    Text(
                                      "Account Created !",
                                      textAlign: TextAlign.center,
                                      style: Theme.of(context)
                                          .textTheme
                                          .titleLarge
                                          ?.copyWith(
                                            color:
                                                AppColors.textPrimaryDarkGrey,
                                          ),
                                    ),
                                  ],
                                ),
                                content: Text(
                                  textAlign: TextAlign.center,
                                  'Your account has been created successfully. Please sign in to continue exploring restaurants.',
                                ),
                                actions: [
                                  SizedBox(
                                    width: double.infinity,
                                    height: 50,
                                    child: ElevatedButton(
                                      onPressed: () {
                                        Navigator.push(
                                          context,
                                          MaterialPageRoute(
                                            builder: (context) =>
                                                const LoginScreen(),
                                          ),
                                        );
                                      },
                                      child: Text('Go to login'),
                                    ),
                                  ),
                                ],
                              );
                            },
                          );
                        } catch (e) {
                          // Login/API error
                          ScaffoldMessenger.of(
                            context,
                          ).showSnackBar(SnackBar(content: Text(e.toString())));
                        } finally {
                          if (mounted) {}
                        }
                      },
                      child: isLoading
                          ? const SizedBox(
                              width: 20,
                              height: 20,
                              child: CircularProgressIndicator(
                                strokeWidth: 2,
                                color: AppColors.surfaceWhite,
                              ),
                            )
                          : const Text('Create Account'),
                    ),
                  ),
                  SizedBox(height: AppSpacing.s24),

                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Text(
                        "Already have an account? ",
                        style: Theme.of(context).textTheme.labelLarge?.copyWith(
                          color: AppColors.textSecondaryLightGrey,
                        ),
                      ),
                      InkWell(
                        onTap: () {
                          Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (context) => const LoginScreen(),
                            ),
                          );
                        },
                        child: Text(
                          "Login",
                          style: Theme.of(context).textTheme.labelLarge
                              ?.copyWith(color: AppColors.primaryWarmOrange),
                        ),
                      ),
                    ],
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
