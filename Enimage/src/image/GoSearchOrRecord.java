package image;

import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class GoSearchOrRecord {

	SearchingImage Search = new SearchingImage();
	SearchingRecord Record = new SearchingRecord();
	
	public void Choose()
	{
		JFrame  frame = new JFrame(); // 프레임 생성 
		JPanel panel = new JPanel();
		JLabel label = new JLabel("some text");  
		JPanel button = new JPanel();
		JButton search = new JButton("검색하기");
		JButton record = new JButton("기록보기");
		JTextField Input = new JTextField(10);
		 	
		button.add(search);
		button.add(record);
		
		panel.add(Input);
		panel.add(button);
		
		
		search.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {

				frame.setVisible(false);

			}
				
		});
		
		search.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {

				frame.setVisible(false);
				//Search.SearchControl();
			}
				
		});
		
		frame.add(panel);
		
		frame.setResizable(false); // 창 크기 조절 불가
		frame.setVisible(true); //창 뜨게하기 
		frame.setPreferredSize(new Dimension(840, 840/12*9));
		frame.setSize(840, 840/12*9);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치  
	}
	
}
