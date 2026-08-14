import 'package:flutter/material.dart';
import 'package:foody_app/core/theme/app_raduis.dart';
import 'package:foody_app/core/theme/app_text_styles.dart';
import 'app_colors.dart';

class AppTheme {
  static ThemeData lightTheme = ThemeData(
    fontFamily: 'Poppins',
    colorScheme: ColorScheme.light(),
    scaffoldBackgroundColor: AppColors.backgroundOffWhite,
    appBarTheme: const AppBarTheme(),
    elevatedButtonTheme: ElevatedButtonThemeData(
      style: ElevatedButton.styleFrom(
        backgroundColor: AppColors.primaryWarmOrange,
        foregroundColor: AppColors.surfaceWhite,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(AppRaduis.medium),
        ),
      ),
    ),
    inputDecorationTheme: InputDecorationTheme(
      filled: true,
      fillColor: AppColors.surfaceWhite,
      hintStyle: TextStyle(color: AppColors.textSecondaryLightGrey),
      border: OutlineInputBorder(
        borderRadius: BorderRadius.circular(AppRaduis.medium),
        borderSide: const BorderSide(color: AppColors.border),
      ),
      enabledBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(AppRaduis.medium),
        borderSide: const BorderSide(color: AppColors.border),
      ),
      focusedBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(AppRaduis.medium),
        borderSide: const BorderSide(color: AppColors.primaryWarmOrange),
      ),
      errorBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(AppRaduis.medium),
        borderSide: const BorderSide(color: AppColors.errorRed),
      ),
      focusedErrorBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(AppRaduis.medium),
        borderSide: const BorderSide(color: AppColors.errorRed),
      ),
    ),
    textTheme: TextTheme(
      headlineLarge: AppTextStyles.headingLarge,
      headlineMedium: AppTextStyles.headineMedium,
      titleLarge: AppTextStyles.titleLarge,
      titleMedium: AppTextStyles.titleMedium,
      bodyLarge: AppTextStyles.bodyLarge,
      bodyMedium: AppTextStyles.bodyMedium,
      bodySmall: AppTextStyles.bodySmall,
      labelLarge: AppTextStyles.labelLarge,
      labelMedium: AppTextStyles.labelMedium,
    ),
  );
}
