package spot_hero_coding_challenge;

class DayCodeException extends RuntimeException {
        DayCodeException(String dayCode){
            super(String.format("Could not convert %s to DayOfWeek", dayCode));
   }
}