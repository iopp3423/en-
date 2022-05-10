package use;


import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Graphics;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.awt.event.ItemEvent;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.JTextField;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import javax.imageio.ImageIO;



public class Screen {
	
	public JFrame frame;
	public JFrame ImageFrame;
	ImageIcon [] imageIcon = new ImageIcon[30];
	JButton [] imageButton = new JButton[30];
	
	public Screen() {
		initialize();
	}
	 
	
	public void initialize()
	{
		frame = new JFrame(); // 프레임 생성
	    ImageFrame = new JFrame();
	    
	    ImageFrame.setSize(400,400); // 더블클릭 이미지 새 창 
	    ImageFrame.setResizable(false); // 창 크기 조절 불가
	    ImageFrame.setPreferredSize(new Dimension(400,400));
	    
		frame.setSize(840, 840/12*9);
		frame.setResizable(false); // 창 크기 조절 불가
		frame.setPreferredSize(new Dimension(840, 840/12*9));	
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치
		
		
		JPanel FirstPanel = new JPanel();
		JPanel SearchPanel = new JPanel(new BorderLayout(100, 100));
		JPanel OneGrid = new JPanel(new GridLayout(2,5));
		JPanel TwoGrid = new JPanel(new GridLayout(4,5));
		JPanel ThreeGrid = new JPanel(new GridLayout(5,6));
		JPanel center = new JPanel();
		JPanel collectPanel = new JPanel(new FlowLayout());
		BorderLayout Border = new BorderLayout();
		FirstPanel.setLayout(null);
				
		JPanel RecordPanel = new JPanel();
		JLabel RecordTitle = new JLabel(" 검 색 기 록 ");
		RecordPanel.setLayout(Border);
		RecordPanel.add(RecordTitle, BorderLayout.NORTH);
		
		
		center.add(ThreeGrid);		
		frame.getContentPane().add(FirstPanel);		
					
		
		///////////////////////////////////////검색 패널 
		String[] Choose = {"10", "20","30"};
		JButton Secondsearch = new JButton("검색하기");
		JButton back = new JButton("뒤로가기");
		JTextField SecondInput = new JTextField(15);
		JComboBox comboBox = new JComboBox(Choose);
		
		Secondsearch.setBounds(500, 50, 100, 40); // 버튼위치
		back.setBounds(600, 50, 100, 40); // 
		SecondInput.setBounds(200,50, 300, 40); // 버튼위치 수
		comboBox.setBounds(700,50, 70, 40);
		
		
		collectPanel.add(SecondInput); // 입력창 
		collectPanel.add(Secondsearch); // 검색버튼 
		collectPanel.add(back);// 뒤로가기 버튼 
		collectPanel.add(comboBox);
		SearchPanel.add(collectPanel,BorderLayout.NORTH);

		
			
			comboBox.addActionListener(new ActionListener(){ // combo에 ActionListner를 설정합니다.
		    public void actionPerformed(ActionEvent e){ // actionPerformed 메서드를 통해 이벤트 처리에 대한 동작을 구현합니다.
		    JComboBox cb = (JComboBox) e.getSource(); // 동작이 일어날 소스를 JComboBox 형태로 받습니다.
		    
		    int index = cb.getSelectedIndex(); // int 타입 index를 선언하고 콤보박스에서 선택된 번호 값으로 저장합니다.
		    frame.getContentPane().removeAll();
		    if(index == 0) 
		    	{
			    	SearchPanel.setVisible(false);				
		    		 for(int OneGridIndex = 0; OneGridIndex<10; OneGridIndex++)
						{
							OneGrid.setSize(300, 200);
							OneGrid.add(imageButton[OneGridIndex]);	
						}
		    		 center.removeAll();
		    		 center.add(OneGrid);
		    		 SearchPanel.add(center,BorderLayout.CENTER);
		    		 frame.getContentPane().add(SearchPanel);
		    		 SearchPanel.setVisible(true);
		    	}
		    
		    else if(index == 1)
		    	{
		    	SearchPanel.setVisible(false);				
	    		 for(int TwoGridIndex = 0; TwoGridIndex<20;TwoGridIndex++)
					{
	    			 	TwoGrid.setSize(300, 200);
	    			 	TwoGrid.add(imageButton[TwoGridIndex]);	
					}
	    		 center.removeAll();
	    		 center.add(TwoGrid);
	    		 SearchPanel.add(center,BorderLayout.CENTER);
	    		 frame.getContentPane().add(SearchPanel);
	    		 SearchPanel.setVisible(true);
		    	}
		    else 
		    	{
		    	SearchPanel.setVisible(false);				
	    		 for(int ThreeGridIndex = 0; ThreeGridIndex<20;ThreeGridIndex++)
					{
	    			 	ThreeGrid.setSize(300, 200);
	    			 	ThreeGrid.add(imageButton[ThreeGridIndex]);	
					}
	    		 center.removeAll();
	    		 center.add(ThreeGrid);
	    		 SearchPanel.add(center,BorderLayout.CENTER);
	    		 frame.getContentPane().add(SearchPanel);
	    		 SearchPanel.setVisible(true);
		    	}
		   } 
		  });
		
			
		Secondsearch.addActionListener(new ActionListener(){ // 검색하기 
			public void actionPerformed(ActionEvent e) {
				
				SearchPanel.setVisible(false);
				//frame.getContentPane().removeAll();
				ThreeGrid.removeAll();
				
				imageIcon = ImagePrint("30",SecondInput.getText()); // 파일 받아오기 	
				for(int index = 0; index<30;index++)
				{
					imageButton[index] = new JButton(new ImageIcon(imageIcon[index].getImage().getScaledInstance(100, 80, Image.SCALE_SMOOTH)));
					ThreeGrid.setSize(300, 200);
					ThreeGrid.add(imageButton[index]);		
					
					JLabel ImageLabel = new JLabel(imageIcon[index]);
					
					imageButton[index].addMouseListener(new MouseAdapter()
					{
					public void mouseClicked(MouseEvent e) {  
						if (e.getClickCount() == 2) {					
							ImageFrame.getContentPane().removeAll();
							ImageFrame.getContentPane().add(ImageLabel);
							ImageFrame.setVisible(false);
							ImageFrame.setVisible(true);						
						}
		            }
				});

				}
				
				frame.getContentPane().removeAll();
				center.removeAll();
				center.add(ThreeGrid);
				SearchPanel.add(center, BorderLayout.CENTER);	
				frame.getContentPane().add(SearchPanel);
				SearchPanel.setVisible(true);			
			}		
		});

					
		back.addActionListener(new ActionListener(){ // 뒤로가기 
			public void actionPerformed(ActionEvent e) {
				
				center.removeAll();
				SearchPanel.setVisible(false);
				frame.getContentPane().removeAll();
				frame.getContentPane().add(FirstPanel);	
				FirstPanel.setVisible(true);
			}
				
		});
		
		


		
		
		////////////////////////처음화면 
		JButton Firstsearch = new JButton("검색하기");
		JButton record = new JButton("기록보기");		
		JTextField Input = new JTextField(10);
		   
        
				
		Firstsearch.setBounds(500, 50, 100, 40); // 버튼위치
		record.setBounds(600, 50, 100, 40); // 
		Input.setBounds(200, 50, 300, 40); // 버튼위치 수
		
		FirstPanel.add(Input);
		FirstPanel.add(Firstsearch);
		FirstPanel.add(record);
		
		Firstsearch.addActionListener(new ActionListener(){ // 검색하기 
			public void actionPerformed(ActionEvent e) {
			
				FirstPanel.setVisible(false);
				frame.getContentPane().removeAll();
				ThreeGrid.removeAll();
				
				imageIcon = ImagePrint("30",Input.getText()); // 파일 받아오기 	
				for(int index = 0; index<30;index++)
				{
					imageButton[index] = new JButton(new ImageIcon(imageIcon[index].getImage().getScaledInstance(100, 80, Image.SCALE_SMOOTH)));
														
					
					ThreeGrid.setSize(300, 200);
					ThreeGrid.add(imageButton[index]);		
					JLabel ImageLabel = new JLabel(imageIcon[index]);
					
					imageButton[index].addMouseListener(new MouseAdapter()
					{
					public void mouseClicked(MouseEvent e) {  
						if (e.getClickCount() == 2) {					
							ImageFrame.getContentPane().removeAll();
							ImageFrame.getContentPane().add(ImageLabel);
							ImageFrame.setVisible(true);						
						}
		            }
				});

				}
				center.removeAll();
				center.add(ThreeGrid);
				SearchPanel.add(center, BorderLayout.CENTER);
				frame.getContentPane().add(SearchPanel);
				SearchPanel.setVisible(true);						
			}				
		});
		
		record.addActionListener(new ActionListener(){ // 기록보기 
			public void actionPerformed(ActionEvent e) {
				
				FirstPanel.setVisible(false);
				frame.getContentPane().removeAll();
				frame.getContentPane().add(RecordPanel);
				System.out.println(Input.getText());
				RecordPanel.setVisible(true);
			}
				
		});
		
	}
        

		public ImageIcon[] ImagePrint(String size, String name) // api 가져오기
		{					
		    String temp;
			String BASE_URL = "https://dapi.kakao.com/v2/search/image?sort=accuracy&page=1&size="+ size + "&query=" + name;
			JSONObject result = null;
			URL url = null;
			URL link = null;
			Image image;
			ImageIcon [] imageicon = new ImageIcon[30];
			
			HttpURLConnection con= null;
			StringBuilder sb = new StringBuilder();
			try {
				// URL 객채 생성 (BASE_URL)
				url = new URL(BASE_URL);
				// URL을 참조하는 객체를 URLConnection 객체로 변환
				con = (HttpURLConnection) url.openConnection();

				// 커넥션 request 방식 "GET"으로 설정
				con.setRequestMethod("GET");

				// 커넥션 request 값 설정(key,value) 
				con.setRequestProperty("Content-type", "application/json");
				// void setRequestProperty (key,value) 다른 예시
				 con.setRequestProperty("Authorization", "KakaoAK 26a41b7bfe87ed292acb3bbb3f064df6");
				// con.setRequestProperty("X-Auth-Token", AUTH_TOKEN);
				// 받아온 JSON 데이터 출력 가능 상태로 변경 (default : false)
				con.setDoOutput(true);

				// 데이터 입력 스트림에 담기
				BufferedReader br = new BufferedReader(new InputStreamReader(con.getInputStream(), "UTF-8"));
				while(br.ready()) {
					sb.append(br.readLine());					
				}
		
				con.disconnect();
			}catch(Exception e) {
				e.printStackTrace();
			}
			
					
				try {
					result = (JSONObject) new JSONParser().parse(sb.toString());
				} catch (ParseException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				
				StringBuilder out = new StringBuilder();
				out.append(result.get("status") +" : " + result.get("status_message") +"\n");
					
		
				
				// JSONObject에서 Array데이터를 get하여 JSONArray에 저장한다.
				JSONArray array = (JSONArray) result.get("documents");

					
				out.append("데이터 출력하기 \n");
				
				for(int i=0; i<array.size(); i++) {		
					JSONObject arr = (JSONObject)array.get(i);
					//System.out.println(arr.get("image_url"));
									
					try {
						link = new URL(arr.get("image_url").toString());
					} catch (MalformedURLException e1) {
						// TODO Auto-generated catch block
						e1.printStackTrace();
					}			
					try {
						image = ImageIO.read(link); // 이미지로 저장 
						imageicon[i] = new ImageIcon(image);
						
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
					
					
				}		
				return imageicon;

		           
				
		}
			
}
