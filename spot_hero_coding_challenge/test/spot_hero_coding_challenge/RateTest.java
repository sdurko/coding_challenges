package spot_hero_coding_challenge;

import java.time.DayOfWeek;
import java.time.LocalTime;
import java.time.OffsetDateTime;
import org.junit.Test;
import static org.junit.Assert.*;

public class RateTest {
    
    /**
     * Test of Initialize method, of class Rate.
     */
    @Test
    public void testInitialize_Positive() {
        System.out.println("Initialize");
        Rate instance = new Rate("mon,tues,wed,thurs,fri","0600-1800",1500);
        instance.Initialize();
        
        LocalTime start = OffsetDateTime.parse("2015-07-01T07:00:00Z").toLocalTime();
        LocalTime end = OffsetDateTime.parse("2015-07-01T12:00:00Z").toLocalTime();
        
        //Demonstrates load occurred properly
        assertEquals(true, instance.MatchesDay(DayOfWeek.MONDAY));
        assertNotEquals(true, instance.MatchesDay(DayOfWeek.SATURDAY));
        assertEquals(Integer.valueOf(1500), instance.GetPrice());
        assertEquals(true, instance.WithinRateTimeFrame(start, end));
    }

    /**
     * Test of GetPrice method, of class Rate.
     */
    @Test
    public void testGetPrice() {
        System.out.println("GetPrice");
        Rate instance = new Rate("mon,tues,wed,thurs,fri","0600-1800",1500);
        instance.Initialize();
        assertEquals(Integer.valueOf(1500), instance.GetPrice());
    }

    /**
     * Test of MatchesDay method, of class Rate.
     */
    @Test
    public void testMatchesDay_ValidDays() {
        System.out.println("MatchesDay-check valid days");
        
        Rate instance = new Rate("mon,tues,wed,thurs,fri","0600-1800",1500);
        instance.Initialize();
        assertEquals(true, instance.MatchesDay(DayOfWeek.MONDAY));
        assertEquals(true, instance.MatchesDay(DayOfWeek.TUESDAY));
        assertEquals(true, instance.MatchesDay(DayOfWeek.WEDNESDAY));
        assertEquals(true, instance.MatchesDay(DayOfWeek.THURSDAY));
        assertEquals(true, instance.MatchesDay(DayOfWeek.FRIDAY));
    }
    
    @Test
    public void testMatchesDay_InvalidDay() {
        System.out.println("MatchesDay-check for invalid day.");
        
        Rate instance = new Rate("mon,tues,wed,thurs,fri","0600-1800",1500);
        instance.Initialize();
        assertNotEquals(true, instance.MatchesDay(DayOfWeek.SATURDAY));
        assertNotEquals(true, instance.MatchesDay(DayOfWeek.SUNDAY));
    }

    /**
     * Test of WithinRateTimeFrame method, of class Rate.
     */
    @Test
    public void testWithinRateTimeFrame_ValidTimes() {
        System.out.println("WithinRateTimeFrame-check valid times");
        
        LocalTime start = OffsetDateTime.parse("2015-07-01T07:00:00Z").toLocalTime();
        LocalTime end = OffsetDateTime.parse("2015-07-01T12:00:00Z").toLocalTime();
        
        Rate instance = new Rate("mon,tues,wed,thurs,fri","0600-1800",1500);
        instance.Initialize();
        assertEquals(true, instance.WithinRateTimeFrame(start, end));
    }
    
    @Test
    public void testWithinRateTimeFrame_InValidTimes() {
        System.out.println("WithinRateTimeFrame-check invalid times");
        
        LocalTime start = OffsetDateTime.parse("2015-07-01T07:00:00Z").toLocalTime();
        LocalTime end = OffsetDateTime.parse("2015-07-01T19:00:00Z").toLocalTime();
        
        Rate instance = new Rate("mon,tues,wed,thurs,fri","0600-1800",1500);
        instance.Initialize();
        assertEquals(false, instance.WithinRateTimeFrame(start, end));
    }
    
    @Test
    public void testWithinRateTimeFrame_InValidStartTime() {
        System.out.println("WithinRateTimeFrame-check invalid start time");
        
        LocalTime start = OffsetDateTime.parse("2015-07-01T04:00:00Z").toLocalTime();
        LocalTime end = OffsetDateTime.parse("2015-07-01T17:00:00Z").toLocalTime();
        
        Rate instance = new Rate("mon,tues,wed,thurs,fri","0600-1800",1500);
        instance.Initialize();
        assertEquals(false, instance.WithinRateTimeFrame(start, end));
    }
    
    @Test
    public void testWithinRateTimeFrame_InValidEndTime() {
        System.out.println("WithinRateTimeFrame-check invalid end time");
        
        LocalTime start = OffsetDateTime.parse("2015-07-01T07:00:00Z").toLocalTime();
        LocalTime end = OffsetDateTime.parse("2015-07-01T18:01:00Z").toLocalTime();
        
        Rate instance = new Rate("mon,tues,wed,thurs,fri","0600-1800",1500);
        instance.Initialize();
        assertEquals(false, instance.WithinRateTimeFrame(start, end));
    }
}