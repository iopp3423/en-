package views;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;

import utility.Constants;

public class PrintLocation {

	
	public void printNotice() {
		System.out.println("Microsoft Windows [Version 10.0.19043.1706]");
		System.out.println("(c) Microsoft Corporation. All rights reserved.");
		System.out.println();
	}
	public void printCurrentLocation(String location, String errorMessage, boolean is_Not_Error)
	{
		if(is_Not_Error) {
			System.out.printf(location);
		}
		else if(!is_Not_Error) {
			System.out.println(errorMessage);
			System.out.printf(location);
		}
	}
	
	public void printDir(SimpleDateFormat date, String attribute, String size, File dirList) {
		
		System.out.printf("%s %3s %6s %s \n",date.format(new Date(dirList.lastModified())), attribute,size,dirList.getName());
	}
	
	
	public void printFileAndDirectoryData(long fileLength, long directoryLength,String fileByte, String directoryByte) {
		
		System.out.printf("%14s�� ���� %17s����Ʈ\n", fileLength, fileByte);
		System.out.printf("%14s�� ���͸� %15s����Ʈ\n\n", directoryLength, directoryByte);
	}
	
	public void printSentence(String sentence) {
		System.out.printf(sentence);
	}
	
	public void printMoveFileSucessOrFail(String sentence , boolean IS_SUCESS) { // move a.txt b.txt ��� 
		if(IS_SUCESS)System.out.printf("%20s\n\n", sentence);
		else if(!IS_SUCESS)System.out.println(sentence + "\n");
	}
	
	public void printHelp() {
		System.out.println("Ư�� ��ɾ ���� �ڼ��� ������ �ʿ��ϸ� HELP ��ɾ� �̸��� �Է��Ͻʽÿ�.\r\n"
				+ "ASSOC    ���� Ȯ��� ������ �����ְų� �����մϴ�.\r\n"
				+ "ATTRIB   ���� �Ӽ��� ǥ���ϰų� �ٲߴϴ�.\r\n"
				+ "BREAK    Ȯ��� CTRL+C �˻縦 �����ϰų� ����ϴ�.\r\n"
				+ "BCDEDIT        ���� �ε��� �����ϱ� ���� ���� �����ͺ��̽����� �Ӽ��� �����մϴ�.\r\n"
				+ "CACLS    ������ �׼��� ��Ʈ�� ���(ACL)�� ǥ���ϰų� �����մϴ�.\r\n"
				+ "CALL     �� �ϰ� ���α׷����� �ٸ� �ϰ� ���α׷��� ȣ���մϴ�.\r\n"
				+ "CD       ���� ���͸� �̸��� �����ְų� �ٲߴϴ�.\r\n"
				+ "CHCP     Ȱ��ȭ�� �ڵ� �������� ��ȣ�� ǥ���ϰų� �����մϴ�.\r\n"
				+ "CHDIR    ���� ���͸� �̸��� �����ְų� �ٲߴϴ�.\r\n"
				+ "CHKDSK   ��ũ�� �˻��ϰ� ���� ������ ǥ���մϴ�.\r\n"
				+ "CHKNTFS  �����ϴ� ���� ��ũ Ȯ���� ȭ�鿡 ǥ���ϰų� �����մϴ�.\r\n"
				+ "CLS      ȭ���� ����ϴ�.\r\n"
				+ "CMD      Windows ��� ������������ �� �ν��Ͻ��� �����մϴ�.\r\n"
				+ "COLOR    �ܼ��� �⺻���� ������ �����մϴ�.\r\n"
				+ "COMP     �� �� �Ǵ� ���� ���� ������ ���մϴ�.\r\n"
				+ "COMPACT  NTFS ���� ������ �ִ� ������ ������ ǥ���ϰų� �����մϴ�.\r\n"
				+ "CONVERT  FAT ������ NTFS�� ��ȯ�մϴ�. ���� ����̺��\r\n"
				+ "         ��ȯ�� �� �����ϴ�.\r\n"
				+ "COPY     �ϳ� �̻��� ������ �ٸ� ��ġ�� �����մϴ�.\r\n"
				+ "DATE     ��¥�� �����ְų� �����մϴ�.\r\n"
				+ "DEL      �ϳ� �̻��� ������ ����ϴ�.\r\n"
				+ "DIR      ���͸��� �ִ� ���ϰ� ���� ���͸� ����� �����ݴϴ�.\r\n"
				+ "DISKPART       ��ũ ��Ƽ�� �Ӽ��� ǥ���ϰų� �����մϴ�.\r\n"
				+ "DOSKEY       ������� �����ϰ�, Windows ����� �ٽ� ȣ���ϰ�,\r\n"
				+ "               ��ũ�θ� ����ϴ�.\r\n"
				+ "DRIVERQUERY    ���� ��ġ ����̹� ���¿� �Ӽ��� ǥ���մϴ�.\r\n"
				+ "ECHO           �޽����� ǥ���ϰų� ECHO�� �Ѱų� ���ϴ�.\r\n"
				+ "ENDLOCAL       ��ġ ���Ͽ��� ȯ�� ������ ����ȭ�� �����ϴ�.\r\n"
				+ "ERASE          �ϳ� �̻��� ������ ����ϴ�.\r\n"
				+ "EXIT           CMD.EXE ���α׷�(��� ����������)�� �����մϴ�.\r\n"
				+ "FC             �� ���� �Ǵ� ���� ������ ���Ͽ� �ٸ� ����\r\n"
				+ "         ǥ���մϴ�.\r\n"
				+ "FIND           ���Ͽ��� �ؽ�Ʈ ���ڿ��� �˻��մϴ�.\r\n"
				+ "FINDSTR        ���Ͽ��� ���ڿ��� �˻��մϴ�.\r\n"
				+ "FOR            ���� ������ �� ���Ͽ� ���� ������ ����� �����մϴ�.\r\n"
				+ "FORMAT         Windows���� ����� ��ũ�� �����մϴ�.\r\n"
				+ "FSUTIL         ���� �ý��� �Ӽ��� ǥ���ϰų� �����մϴ�.\r\n"
				+ "FTYPE          ���� Ȯ��� ���ῡ ���Ǵ� ���� ������ ǥ���ϰų�\r\n"
				+ "               �����մϴ�.\r\n"
				+ "GOTO           Windows ��� ���������Ͱ� �ϰ� ���α׷�����\r\n"
				+ "               �̸�ǥ�� �ٿ��� �ٷ� �̵��մϴ�.\r\n"
				+ "GPRESULT       ��ǻ�� �Ǵ� ����ڿ� ���� �׷� ��å ������ ǥ���մϴ�.\r\n"
				+ "GRAFTABL       Windows�� �׷��� ��忡�� Ȯ�� ���� ��Ʈ�� ǥ����\r\n"
				+ "         �� �ְ� �մϴ�.\r\n"
				+ "HELP           Windows ��ɿ� ���� ���� ������ �����մϴ�.\r\n"
				+ "ICACLS         ���ϰ� ���͸��� ���� ACL�� ǥ��, ����, ��� �Ǵ�\r\n"
				+ "               �����մϴ�.\r\n"
				+ "IF             �ϰ� ���α׷����� ���� ó���� �����մϴ�.\r\n"
				+ "LABEL          ��ũ�� ���� �̸��� ����ų�, �ٲٰų�, ����ϴ�.\r\n"
				+ "MD             ���͸��� ����ϴ�.\r\n"
				+ "MKDIR          ���͸��� ����ϴ�.\r\n"
				+ "MKLINK         �ٷ� ���� ��ũ�� �ϵ� ��ũ�� ����ϴ�.\r\n"
				+ "MODE           �ý��� ��ġ�� �����մϴ�.\r\n"
				+ "MORE           ����� �ѹ��� �� ȭ�龿 ǥ���մϴ�.\r\n"
				+ "MOVE           �ϳ� �̻��� ������ �� ���͸����� �ٸ� ���͸���\r\n"
				+ "               �̵��մϴ�.\r\n"
				+ "OPENFILES      ���� �������� ���� ����ڿ� ���� ���� ������ ǥ���մϴ�.\r\n"
				+ "PATH           ���� ������ ã�� ��θ� ǥ���ϰų� �����մϴ�.\r\n"
				+ "PAUSE          ��ġ ������ ó���� �Ͻ� �ߴ��ϰ� �޽����� ǥ���մϴ�.\r\n"
				+ "POPD           PUSHD�� ���� ����� ���� ���͸��� ���� ����\r\n"
				+ "               �����մϴ�.\r\n"
				+ "PRINT          �ؽ�Ʈ ������ �μ��մϴ�.\r\n"
				+ "PROMPT         Windows ��� ������Ʈ�� �����մϴ�.\r\n"
				+ "PUSHD          ���� ���͸��� ������ ���� �����մϴ�.\r\n"
				+ "RD             ���͸��� �����մϴ�.\r\n"
				+ "RECOVER        �ҷ��̰ų� ������ �ִ� ��ũ���� ���� �� �ִ� ������ �����մϴ�.\r\n"
				+ "REM            ��ġ ���� �Ǵ� CONFIG.SYS�� �ּ��� ����մϴ�.\r\n"
				+ "REN            ���� �̸��� �ٲߴϴ�.\r\n"
				+ "RENAME         ���� �̸��� �ٲߴϴ�.\r\n"
				+ "REPLACE        ������ �ٲߴϴ�.\r\n"
				+ "RMDIR          ���͸��� �����մϴ�.\r\n"
				+ "ROBOCOPY       ���ϰ� ���͸� Ʈ���� ������ �� �ִ� ��� ��ƿ��Ƽ�Դϴ�.\r\n"
				+ "SET            Windows ȯ�� ������ ǥ��, ���� �Ǵ� �����մϴ�.\r\n"
				+ "SETLOCAL       ��ġ ���Ͽ��� ȯ�� ������ ����ȭ�� �����մϴ�.\r\n"
				+ "SC             ����(��׶��� ���μ���)�� ǥ���ϰų� �����մϴ�.\r\n"
				+ "SCHTASKS       ��ǻ�Ϳ��� ������ ��ɰ� ���α׷��� �����մϴ�.\r\n"
				+ "SHIFT          ��ġ ���Ͽ��� �ٲ� �� �ִ� �Ű� ������ ��ġ�� �ٲߴϴ�.\r\n"
				+ "SHUTDOWN       ��ǻ���� ���� �Ǵ� ���� ���Ḧ ����մϴ�.\r\n"
				+ "SORT           �Է��� �����մϴ�.\r\n"
				+ "START          ������ ���α׷��̳� ����� ������ ������ â�� �����մϴ�.\r\n"
				+ "SUBST          ��θ� ����̺� ���ڿ� �����մϴ�.\r\n"
				+ "SYSTEMINFO     ��ǻ�ͺ� �Ӽ��� ������ ǥ���մϴ�.\r\n"
				+ "TASKLIST       ���񽺸� �����Ͽ� ���� ���� ���� ��� �۾��� ǥ���մϴ�.\r\n"
				+ "TASKKILL       ���� ���� ���μ����� ���� ���α׷��� �ߴ��մϴ�.\r\n"
				+ "TIME           �ý��� �ð��� ǥ���ϰų� �����մϴ�.\r\n"
				+ "TITLE          CMD.EXE ���ǿ� ���� â ������ �����մϴ�.\r\n"
				+ "TREE           ����̺� �Ǵ� ����� ���͸� ������ �׷�������\r\n"
				+ "               ǥ���մϴ�.\r\n"
				+ "TYPE           �ؽ�Ʈ ������ ������ ǥ���մϴ�.\r\n"
				+ "VER            Windows ������ ǥ���մϴ�.\r\n"
				+ "VERIFY         ������ ��ũ�� �ùٷ� ��ϵǾ����� ��������\r\n"
				+ "         ���θ� �����մϴ�.\r\n"
				+ "VOL            ��ũ ���� ���̺�� �Ϸ� ��ȣ�� ǥ���մϴ�.\r\n"
				+ "XCOPY          ���ϰ� ���͸� Ʈ���� �����մϴ�.\r\n"
				+ "WMIC           ��ȭ�� ��� �� ���� WMI ������ ǥ���մϴ�.\r\n"
				+ "\r\n"
				+ "������ ���� �ڼ��� ������ �¶��� ������ ����� ������ �����Ͻʽÿ�.");
	}
}