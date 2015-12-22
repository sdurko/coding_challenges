package spot_hero_coding_challenge;

import java.time.OffsetDateTime;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

public class RatesTest {
    
    private Rates instance;
    
    @Before
    public void setUp() {
       Rate[] rates = new Rate[]{
        new Rate("mon,tues,thurs","0900-2100",1500),
        new Rate("fri,sat,sun","0900-2100",2000),
        new Rate("wed","0600-1800",1750),
        new Rate("mon,wed,sat","0100-0500",1000),
        new Rate("sun,tues","0100-0700",925)};
    
        instance = new Rates(rates);
        instance.Initialize();  //calls individual Rate initializer
    }
    
    @After
    public void tearDown() {
        instance = null;
    }

    /**
     * Test of Initialize method, of class Rates.
     */
    @Test
    public void testInitialize() {
        System.out.println("Initialize");
        instance.Initialize();  //calls individual Rate initializer
        assertNotNull(instance);
    }

    /**
     * Test of FindRate method, of class Rates.
     */
    @Test
    public void testFindRate_PositiveResult_Mon9to12() {
        System.out.println("FindRate-positive result mon 0900-1200");
        AssertRateFound("2015-07-06T09:00:00Z", "2015-07-06T20:59:00Z", 1500);             
    } 
    
    @Test
    public void testFindRate_NegativeResult_Mon9to12() {
        System.out.println("FindRate-negative result mon 0900-1200");
        AssertRateNotFound("2015-07-06T09:00:00Z", "2015-07-06T21:00:00Z");               
    } 
    
    @Test
    public void testFindRate_PositiveResult_Mon1to5() {
        System.out.println("FindRate-positive result mon 0100-0500");        
        AssertRateFound("2015-07-06T01:00:00Z", "2015-07-06T04:59:00Z", 1000);             
    } 
    
    @Test
    public void testFindRate_NegativeResult_Mon1to5() {
        System.out.println("FindRate-negative result mon 0100-0500");
        AssertRateNotFound("2015-07-06T01:00:00Z", "2015-07-06T05:00:00Z");                   
    } 
    
    @Test
    public void testFindRate_PositiveResult_Wed1to5() {
        System.out.println("FindRate-positive result wed 0100-0500");
        AssertRateFound("2015-07-01T01:00:00Z", "2015-07-01T04:59:00Z", 1000);              
    } 
    
    @Test
    public void testFindRate_NegativeResult_Wed1to5() {
        System.out.println("FindRate-negative result wed 0100-0500");
        AssertRateNotFound("2015-07-01T01:00:00Z", "2015-07-01T05:00:00Z");                
    } 
    
    @Test
    public void testFindRate_PositiveResult_Wed6to6() {
        System.out.println("FindRate-positive result wed 0600-1800");
        AssertRateFound("2015-07-01T06:00:00Z", "2015-07-01T17:59:00Z", 1750);               
    } 
    
    @Test
    public void testFindRate_NegativeResult_Wed6to6() {
        System.out.println("FindRate-negative result wed 0600-1800");
        AssertRateNotFound("2015-07-01T06:00:00Z", "2015-07-01T18:00:00Z");                
    } 

    @Test
    public void testFindRate_PositiveResult_Sun1to7() {
        System.out.println("FindRate-positive result sun 0100-0700");
        AssertRateFound("2015-07-05T01:00:00Z", "2015-07-05T06:59:00Z", 925);              
    } 
    
    @Test
    public void testFindRate_NegativeResult_Sun1to7() {
        System.out.println("FindRate-negative result sun 0100-0700");
        AssertRateNotFound("2015-07-05T01:00:00Z", "2015-07-05T07:00:00Z");                    
    } 
    
    @Test
    public void testFindRate_PositiveResult_Sun9to9() {
        System.out.println("FindRate-positive result sun 0900-2100");
        AssertRateFound("2015-07-05T09:00:00Z", "2015-07-05T20:59:00Z", 2000);              
    } 
    
    @Test
    public void testFindRate_NegativeResult_Sun9to9() {
        System.out.println("FindRate-negative result sun 0900-2100");
        AssertRateNotFound("2015-07-05T09:00:00Z", "2015-07-05T21:00:00Z");                    
    } 
    
    @Test
    public void testFindRate_NegativeResult_Sun9to9_BeforeRate() {
        System.out.println("FindRate-negative result sun 0900-2100 before rate");
        AssertRateNotFound("2015-07-05T08:59:00Z", "2015-07-05T20:00:00Z");                  
    } 
    
    @Test
    public void testFindRate_PositiveResult_Thurs9to9() {
        System.out.println("FindRate-positive result thurs 0900-2100");
        AssertRateFound("2015-07-05T09:00:00Z", "2015-07-05T20:59:00Z", 2000);              
    } 
    
    @Test
    public void testFindRate_NegativeResult_Thurs9to9() {
        System.out.println("FindRate-negative result thurs 0900-2100");
        AssertRateNotFound("2015-07-05T09:00:00Z","2015-07-05T21:00:00Z");                   
    } 
    
    @Test
    public void testFindRate_NegativeResult_Thurs9to9_BeforeRate() {
        System.out.println("FindRate-negative result thurs 0900-2100 before rate");
        AssertRateNotFound("2015-07-05T08:59:00Z","2015-07-05T20:00:00Z");                    
    } 
    
    @Test
    public void testFindRate_DifferentDays() {
        System.out.println("FindRate-different days");
        AssertRateNotFound("2015-07-01T07:00:00Z","2015-07-02T12:00:00Z");
    }
    
    @Test
    public void testFindRate_SameDayAWeekApart() {
        System.out.println("FindRate-same day a week apart");
        AssertRateNotFound("2015-07-04T10:00:00Z","2015-07-11T19:00:00Z");
    }
    
    private void AssertRateFound(String startTime, String endTime, Integer price) {
        OffsetDateTime start = OffsetDateTime.parse(startTime);
        OffsetDateTime end = OffsetDateTime.parse(endTime);
        
        Rate rate = instance.FindRate(start, end);
        System.out.println(rate.GetPrice());
        assertNotNull(rate);       
        assertEquals(price, rate.GetPrice()); 
    }
    
    private void AssertRateNotFound(String startTime, String endTime) {
        OffsetDateTime start = OffsetDateTime.parse(startTime);
        OffsetDateTime end = OffsetDateTime.parse(endTime);
        assertNull(instance.FindRate(start, end));    
    }
}