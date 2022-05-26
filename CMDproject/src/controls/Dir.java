package controls;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;

import models.RouteLocation;
import utility.Constants;
import views.PrintLocation;

public class Dir {
	private RouteLocation location;
	private PrintLocation print;
	
	public Dir(RouteLocation location, PrintLocation print) {
		this.location = location;
		this.print = print;
	}
	
	public void dir() {
		File currentLocation = new File(location.getCurrentLocation());
		
		if(currentLocation.isDirectory()) {
		    File[] dirList = currentLocation.listFiles(); // 현재위치
		    SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd a HH:mm"); // 시간 
		    
		    for(int index=Constants.START; index < dirList.length; index++) {
		        //System.out.println(dirList[index].getName());
		    
		    String attribute = "";
		    String size = "";
		    
		    if(dirList[index].isDirectory()){
		        attribute = "DIR";
		       }
		    if(dirList[index].length() != Constants.RESET ) {
		    	size = dirList[index].length() + "";
		    }

		    print.printDir(date, attribute, size, dirList[index]); // dir 출력

		    }
		    print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
	    
		}
		
		
	
        
        /*
       // 디렉토리 전체 용량
        System.out.println("전체 용량 : " +  FileUtils.sizeOfDirectory(new File(location.getCurrentLocation())) + "Byte");
        
        
        // 하위의 모든 파일
        for (File info : FileUtils.listFiles(new File(location.getCurrentLocation()), TrueFileFilter.INSTANCE, TrueFileFilter.INSTANCE)) {
            System.out.println(info.getName());
        }
        
         // 하위의 모든 디렉토리
        for (File info : FileUtils.listFilesAndDirs(new File(location.getCurrentLocation()), TrueFileFilter.INSTANCE, TrueFileFilter.INSTANCE)) {
            if(info.isDirectory()) {
                System.out.println(info.getName());
            }
        }
        */
	}
}