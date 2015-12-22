package spot_hero_coding_challenge;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.io.FileNotFoundException;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

class RatesFileParser {    
    Rates LoadRates (String filePath) {
        Rates rates = null;

        try (FileReader fr = new FileReader(GetFile(filePath))){
           Gson gson = new GsonBuilder().create();
           rates = gson.fromJson(fr, Rates.class); 
        }
        catch(IOException e){	
            throw new RuntimeException(e);
        }
        
        rates.Initialize();
        return rates;
    } 
    
    private File GetFile(String filePath) throws FileNotFoundException {   
        File file = new File(filePath);
       
        if(!file.exists())
            throw new FileNotFoundException(String.format("The file %s could not be found. ",filePath));

        return file;
    }
}