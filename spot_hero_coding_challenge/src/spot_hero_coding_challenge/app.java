package spot_hero_coding_challenge;

import java.time.OffsetDateTime;

class app {

    public static void main(String[] args) {
                
        if(!new ArgValidator().ArgsAreValid(args)) 
                System.exit(0);

        Rates rates = new RatesFileParser().LoadRates(args[0]);
        Rate rate = rates.FindRate(OffsetDateTime.parse(args[1]),OffsetDateTime.parse(args[2]));
        System.out.println(rate != null ? rate.GetPrice() : "unavailable");
    }
}