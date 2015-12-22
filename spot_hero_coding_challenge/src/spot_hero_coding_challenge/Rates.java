package spot_hero_coding_challenge;

import java.time.OffsetDateTime;

class Rates {
    private final Rate[] rates;
    
    Rates(Rate[] ratesData){
        rates = ratesData;
    }
    
    void Initialize(){   
        for(Rate rate : rates)
            rate.Initialize();
    }
    
    Rate FindRate(OffsetDateTime start, OffsetDateTime end){   
        System.out.println(String.format("Start: %s End: %s", start,end));   
        
        if(DatesAreInValid(start,end))
            return null;

        for(Rate rate : rates)
            if(rate.MatchesDay(start.getDayOfWeek()) 
                    && rate.WithinRateTimeFrame(start.toLocalTime(), end.toLocalTime()))
                return rate;

        return null;
    } 
    
    private Boolean DatesAreInValid(OffsetDateTime start, OffsetDateTime end){
       return start.isAfter(end) 
                || start.getDayOfMonth() != end.getDayOfMonth();
    }
}