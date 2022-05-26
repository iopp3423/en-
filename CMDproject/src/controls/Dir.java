package controls;

import java.io.File;

import models.RouteLocation;
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
		    File[] fList = currentLocation.listFiles();
		    for(int i=0; i < fList.length; i++)
		        System.out.println(fList[i].getName());
		}
	}
}