package image;

import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JComponent;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class SearchingImage {
		

	public SearchingImage()
	{
		JFrame  frame = new JFrame(); // 프레임 생성 
		JButton search = new JButton("검색하기");
		JButton back = new JButton("뒤로가기");
		JPanel button = new JPanel();
		JPanel panel = new JPanel();
		JTextField Input = new JTextField(10);
		
		
		button.add(search);
		button.add(back);
		panel.add(Input);
		panel.add(button);
		
		
		back.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {
				
				frame.setVisible(false);
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
	
	
	
	
	/*
	public void SearchImage()
	{
		String query = "page:2, size:30, sort:accracy";
		String url = "https://dapi.kakao.com/v2/search/image?" + query;
		String headers = "Authorization : KakaoAK 26a41b7bfe87ed292acb3bbb3f064df6";
		
		getesponse = request.post(url, headers=headers);
		if (response.status_code != 200)
		    System.out.println("error! because ");
		else
		{
		    int count = 0;
		    System.out.println(response.json()["image_url"])
		        //print(f"[{count}th] image_url =", image_info["image_url"])
		}		
	}
	*/
}
