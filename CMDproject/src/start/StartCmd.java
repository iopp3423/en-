package start;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

import controls.CmdController;
import utility.Constants;

public class StartCmd {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		CmdController controller = new CmdController();
		controller.cmdControl();
		/*
		try {
			String line;
			InputStream cmdNumber;
			cmdNumber = Runtime.getRuntime().exec("cmd").getInputStream();
			BufferedReader bufferReader = new BufferedReader(new InputStreamReader(cmdNumber, "MS949"));
			for(int index=Constants.START;index<Constants.CMD_NUMBER;index++) {
				line = bufferReader.readLine();
				System.out.println(line);
			}
			System.out.println();
			bufferReader.close();
			cmdNumber.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
		*/

	}

}