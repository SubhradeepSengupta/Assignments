//
//  ViewController.h
//  Assignment1_4
//
//  Created by Subhradeep  on 3/18/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewController : UIViewController {
    NSString *firstEntry;
    NSString *secondEntry;
    NSString *dotOperator;
    BOOL operatorPressed;
}

@property (strong, nonatomic) IBOutlet UILabel *viewArea;
@property (strong, nonatomic) IBOutlet UIButton *dotButton;

- (IBAction)clearButton:(id)sender;
- (IBAction)equalsButton:(id)sender;
- (IBAction)operatorPressed:(id)sender;
- (IBAction)operandPressed:(id)sender;


@end
