package use;

import java.awt.*;
import javax.swing.*;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextField;


public class Screen {
	//private Image  image;
	
	
	public Screen()
	{
		JFrame frame = new JFrame(); // 프레임 생성 
		JButton search = new JButton("검색하기");
		JButton record = new JButton("기록보기");
		JPanel panel = new JPanel();
		JPanel button = new JPanel();
		JTextField Input = new JTextField(10);
		
		//this.image = image;
		//setSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		//setLayout(null);
		 	
		button.add(search);
		button.add(record);
		
		panel.add(Input);
		panel.add(button);
		
		frame.add(panel);
		
		
		
		search.addActionListener(new ActionListener(){ // 검색하기 
			public void actionPerformed(ActionEvent e) {

				frame.setVisible(false);
				SearchingImage(); // 검색하기 
				
			}
				
		});
		
		record.addActionListener(new ActionListener(){ // 기록보기 
			public void actionPerformed(ActionEvent e) {

				frame.setVisible(false);
				CheckLog(); // 기록보기 
			}
				
		});
		frame.setResizable(false); // 창 크기 조절 불가
		frame.setVisible(true); //창 뜨게하기 
		frame.setPreferredSize(new Dimension(840, 840/12*9));
		frame.setSize(840, 840/12*9);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치  
		
	
	}

	
	public void SearchingImage() // 검색하기 
	{
		JFrame frame = new JFrame(); // 프레임 생성 
		String[] Choose = {"10", "20","30"};
		
		JButton search = new JButton("검색하기");
		JButton back = new JButton("뒤로가기");
		JPanel button = new JPanel();
		JPanel panel = new JPanel();
		JPanel gridOne = new JPanel(new GridLayout(2,5));
		JPanel gridTwo = new JPanel(new GridLayout(4,5));
		JPanel gridThree = new JPanel(new GridLayout(6,5));
		
		JTextField Input = new JTextField(10);
		JComboBox comboBox = new JComboBox(Choose);
		
		String name[] = {"컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1","컴포턴트 1"};
			
		button.add(search);
		button.add(back);
		panel.add(Input);
		panel.add(button);
		panel.add(comboBox);
		
		for(int i=0;i<10;i++)
		{
			JButton jb = new JButton(name[i]);
			gridOne.setSize(300, 200);
			gridOne.add(jb);
		}

		panel.add(gridOne);
		frame.add(panel);
		
		
		
		back.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {
				
				frame.setVisible(false);
				Screen screen = new Screen();
			}
				
		});
		
		frame.setResizable(false); // 창 크기 조절 불가
		frame.setVisible(true); //창 뜨게하기 
		frame.setPreferredSize(new Dimension(840, 840/12*9));
		frame.setSize(840, 840/12*9);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치  
		
		
	}
	
	
	
	public void CheckLog() // 기록보기  
	{	
		JFrame frame = new JFrame(); // 프레임 생성 
		
		JButton search = new JButton("검색하기");
		JButton back = new JButton("뒤로가기");
		JPanel button = new JPanel();
		JPanel panel = new JPanel();
		JLabel title = new JLabel("로그 기록");
		title.setSize(150, 150);
		//JTextField Input = new JTextField(10);
		
		
		
		button.add(search);
		button.add(back);
		frame.add(title);
		panel.add(button);
		
		frame.add(panel);
		
		
		back.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {
				
				//frame.setVisible(false);
			}
				
		});
		
		frame.setResizable(false); // 창 크기 조절 불가
		frame.setVisible(true); //창 뜨게하기 
		frame.setPreferredSize(new Dimension(840, 840/12*9));
		frame.setSize(840, 840/12*9);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치  
		
	}
	
	/*
	public void paintComponent(Graphics image)
	{
		image.drawImage(image, 0, 0, null);
	}
	*/
	
	
	
	
	public void AdjustFrame()
	{
	
	}
	
}
