package spot_hero_coding_challenge;

class ArgValidator {
    
    Boolean ArgsAreValid(String[] args) {
        if(args.length != 3) {
            System.out.println("Invalid amount of arguements!  Expecting FilePath, Start DateTime, End DateTime");
            return false;
        }

        if(!IsJsonFile(args[0])) {
            System.out.println("Invalid file type! File needs to be .json");
            return false;
        }
        
        if(!IsValidDateTimeLength(args[1])) {
            System.out.println("Invalid start date/time! File needs to be in isoformat");
            return false;
        }
        
        if(!IsValidDateTimeLength(args[2])) {
            System.out.println("Invalid end date/time! File needs to be in isoformat");
            return false;
        }
        
        return true;
    }
    
    private Boolean IsJsonFile(String filePath) {
        return "json".equals(filePath.split("\\.")[1]);
    }
    
    private Boolean IsValidDateTimeLength(String dateTimeData) {
        return dateTimeData.length() == 20;
    }
}