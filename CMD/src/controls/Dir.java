package controls;

import java.io.File;

import models.RouteLocation;
import utility.Constants;
import views.PrintLocation;
//import org.apache.commons.io.FileUtils;
//import org.apache.commons.io.filefilter.TrueFileFilter;

public class Dir {
	private RouteLocation location;
	private PrintLocation print;
	
	public Dir(RouteLocation location, PrintLocation print) {
		this.location = location;
		this.print = print;
	}
	
	public void dir(String dirAndLocation) {
		
		File currentLocation = new File(location.getCurrentLocation());
			
		if(currentLocation.isDirectory()) {
		    File[] dirList = currentLocation.listFiles();
		    for(int index=Constants.START; index < dirList.length; index++)
		        System.out.println(dirList[index].getName());
		}
		
		
		// ���� ���丮 
        for (File info : new File(location.getCurrentLocation()).listFiles()) {
            if (info.isDirectory()) {
                System.out.println(info.getName());
            }
            if (info.isFile()) {
                System.out.println(info.getName());
            }
        }
        
        /*
        // ���丮 ��ü �뷮
        System.out.println("��ü �뷮 : " +  FileUtils.sizeOfDirectory(new File(location.getCurrentLocation())) + "Byte");
        
        
        // ������ ��� ����
        for (File info : FileUtils.listFiles(new File(location.getCurrentLocation()), TrueFileFilter.INSTANCE, TrueFileFilter.INSTANCE)) {
            System.out.println(info.getName());
        }
        
        // ������ ��� ���丮
        for (File info : FileUtils.listFilesAndDirs(new File(location.getCurrentLocation()), TrueFileFilter.INSTANCE, TrueFileFilter.INSTANCE)) {
            if(info.isDirectory()) {
                System.out.println(info.getName());
            }
        }
        */
    }
	
}
