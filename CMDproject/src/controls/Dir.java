package controls;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
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
	
	
	public void printCurrentLocationDir() {
		File currentLocation = new File(location.getCurrentLocation());
		long length = Constants.RESET;
		
		
		//if(currentLocation.isDirectory()) {
		    File[] dirList = currentLocation.listFiles(); // 현재위치
		    SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd a HH:mm"); // 시간 
		    
		    for(int index=Constants.START; index < dirList.length; index++) {
		    	
		    String attribute = "";
		    String size = "";
		    
		    if(dirList[index].isDirectory()){
		        attribute = "DIR";
		       }
		    if(dirList[index].length() != Constants.RESET ) {
		    	size = dirList[index].length() + "";
		    }
		    
		   
	            length ++;
	        
		    print.printDir(date, attribute, size, dirList[index]); // dir 출력

		    }
		    print.printCurrentLocation("C:" + location.getCurrentLocation() + ">", location.getErrorMessage(), !Constants.IS_ERROR);  // 현재 위치 출력
		    System.out.println(length);
		}
		
	//}
	
	public long folderFileCount(File directory) {
	    long length = 0;
	    try {
	        for (File file : directory.listFiles()) {
	            if (file.isFile())
	                length++;  //폴더 내부 파일 갯수
	        else
	            length += folderFileCount(file);
	        }			
	    } catch (Exception e) {

	    }
	    return length;
	}
	
	public long getFolderSize(File folder) {
		//System.out.println("dd");
	    long length = Constants.RESET;
	    File[] files = folder.listFiles();
	    int count = files.length;
	   
	    for (int index = 0; index < count; index++) {
	        if (files[index].isFile()) {
	            length += files[index].length();
	        } else {
	            length += getFolderSize(files[index]);
	        }
	        
	    }
	    
	    return length;
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