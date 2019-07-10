//
//  ViewController.h
//  Assignment1_1
//
//  Created by Subhradeep  on 3/14/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewController : UIViewController

@property (weak, nonatomic) IBOutlet UITextField *inputText;

@property (weak, nonatomic) IBOutlet UILabel *labelText;

- (IBAction)actionButton:(id)sender;

@end

