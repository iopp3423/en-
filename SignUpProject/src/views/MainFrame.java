package views;

import java.awt.Dimension;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import utility.Constants;

public class MainFrame{
	
	public MainPanel mainPanel;
	public JFrame mainFrame;

	
	public void setFrame() {
		mainFrame = new JFrame();
		
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/사진1.png"));
		MainPanel mainPanel = new MainPanel(new ImageIcon(imageIcon.getImage().getScaledInstance(1280, 720, Image.SCALE_SMOOTH)).getImage(), mainFrame);
		
		mainFrame.add(mainPanel);
			
		mainFrame.setSize(Constants.SCREEN_SIZE_WIDTH,Constants.SCREEN_SIZE_HEIGHT);
		mainFrame.setPreferredSize(new Dimension(Constants.SCREEN_SIZE_WIDTH, Constants.SCREEN_SIZE_HEIGHT));	
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		mainFrame.setLocationRelativeTo(null); // 화면 나오는 위치
		mainFrame.setVisible(true);
		mainFrame.pack();
	}
	
}
