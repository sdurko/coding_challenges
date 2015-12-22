package spot_hero_coding_challenge;

import org.junit.Test;
import static org.junit.Assert.*;

public class ArgValidatorTest {
    
    /**
     * Test of CheckArgs method, of class ArgValidator.
     */
    @Test
    public void testCheckArgs_CorrectInput() {
        System.out.println("CheckArgs-correct input");
        String[] args = new String[]{"rates_example.json","2015-07-01T07:00:00Z","2015-07-01T12:00:00Z"};
        assertEquals(true, new ArgValidator().ArgsAreValid(args));
    }
    
    @Test
    public void testCheckArgs_WrongFileExtension() {
        System.out.println("CheckArgs-wrong file extension");
        String[] args = new String[]{"rates_example.doc","2015-07-01T07:00:00Z","2015-07-01T12:00:00Z"};
        assertEquals(false, new ArgValidator().ArgsAreValid(args));
    }
    
    @Test
    public void testCheckArgs_4Args() {
        System.out.println("CheckArgs-four args");
        String[] args = new String[]{"rates_example.json", "2015-07-01T07:00:00Z", "2015-07-01T12:00:00Z", "Junk"};
        assertEquals(false, new ArgValidator().ArgsAreValid(args));
    }
    
    @Test
    public void testCheckArgs_2Args() {
        System.out.println("CheckArgs-two args");
        String[] args = new String[]{"2015-07-01T07:00:00Z", "2015-07-01T12:00:00Z"};
        assertEquals(false, new ArgValidator().ArgsAreValid(args));
    }
    
        @Test
    public void testCheckArgs_ValidStartDateLength() {
        System.out.println("CheckArgs-valid start date length");
        String[] args = new String[]{"rates_example.json", "2015-07-01T07:00:00Z", "2015-07-01T12:00:00Z"};
        assertEquals(true, new ArgValidator().ArgsAreValid(args));
    }
    
    @Test
    public void testCheckArgs_ValidEndDateLength() {
        System.out.println("CheckArgs-valid end date length");
        String[] args = new String[]{"rates_example.json", "2015-07-01T07:00:00Z", "2015-07-01T12:00:00Z"};
        assertEquals(true, new ArgValidator().ArgsAreValid(args));
    } 
    
    @Test
    public void testCheckArgs_InValidStartDateLength() {
        System.out.println("CheckArgs-invalid start date length");
        String[] args = new String[]{"rates_example.json", "2015-07-01", "2015-07-01T12:00:00Z"};
        assertEquals(false, new ArgValidator().ArgsAreValid(args));
    }
    
    @Test
    public void testCheckArgs_InValidEndDateLength() {
        System.out.println("CheckArgs-invalid end date length");
        String[] args = new String[]{"rates_example.json", "2015-07-01T07:00:00Z", "2:00:00Z"};
        assertEquals(false, new ArgValidator().ArgsAreValid(args));
    } 
}