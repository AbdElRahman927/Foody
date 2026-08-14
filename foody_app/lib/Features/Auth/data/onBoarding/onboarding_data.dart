import 'package:foody_app/core/constants/assets_constants.dart';
import 'package:foody_app/features/auth/data/onBoarding/onboarding_model.dart';

final List<OnboardingModel> onboardingPages = [
  OnboardingModel(
    title1: 'Discover Restaurants',
    title2:
        'Find amazing restaurants nearby and explore a world of cuisines right at your fingertips.',
    index: 0,
    photo: AssetsConstants.onBoarding1,
  ),
  OnboardingModel(
    title1: 'Trusted Reviews',
    title2:
        'Read honest reviews and real ratings from food lovers before you decide where to eat.',
    index: 1,
    photo: AssetsConstants.onBoarding2,
  ),
  OnboardingModel(
    title1: 'Save Favorites',
    title2:
        'Bookmark your favorite restaurants and access them instantly whenever you crave them.',
    index: 2,
    photo: AssetsConstants.onBoarding3,
  ),
];
