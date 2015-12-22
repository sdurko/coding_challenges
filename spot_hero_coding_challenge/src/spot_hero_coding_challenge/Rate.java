package spot_hero_coding_challenge;

import java.time.DayOfWeek;
import java.util.ArrayList;
import java.util.List;
import java.time.LocalTime;

class Rate {
    private List<DayOfWeek> daysOfRate;
    private LocalTime rateStart;
    private LocalTime rateEnd;
    
    private final String days;
    private final String times;
    private final Integer price;
    
    Rate(String rateDays, String rateTimes, Integer ratePrice) {
        days = rateDays;
        times = rateTimes;
        price = ratePrice;
    }
          
    void Initialize(){
        LoadRateDays();
        LoadRateTimes();
    }

    Integer GetPrice(){
        return price;
    }
    
    Boolean MatchesDay(DayOfWeek dayOfWeek) {
        return daysOfRate.contains(dayOfWeek);
    }
    
    Boolean WithinRateTimeFrame(LocalTime start, LocalTime end) { 
        
        return (start.equals(rateStart) || start.isAfter(rateStart)) 
                    && end.isBefore(rateEnd);        
    }
    
    private void LoadRateDays() {
        daysOfRate = new ArrayList<>();
        for (String day : days.split(","))
                daysOfRate.add(ToDayOfWeek(day));
    }
    
    private void LoadRateTimes() {
        String[] timeOfDay = times.split("-");
        rateStart = GetRateTime(timeOfDay[0]);
        rateEnd = GetRateTime(timeOfDay[1]);
    }
    
    private LocalTime GetRateTime(String timeOfDay) {
        int hour = Integer.valueOf(timeOfDay.substring(0, 2));
        int minute = Integer.valueOf(timeOfDay.substring(2, 4));
        return LocalTime.of(hour,minute);
    }
    
    private DayOfWeek ToDayOfWeek(String dayCode) {
        switch(dayCode){
            case "sun": return DayOfWeek.SUNDAY;
            case "mon": return DayOfWeek.MONDAY;
            case "tues": return DayOfWeek.TUESDAY;
            case "wed": return DayOfWeek.WEDNESDAY;
            case "thurs": return DayOfWeek.THURSDAY;
            case "fri": return DayOfWeek.FRIDAY;
            case "sat": return DayOfWeek.SATURDAY;
            default: throw new DayCodeException(dayCode);
        }
    }
}