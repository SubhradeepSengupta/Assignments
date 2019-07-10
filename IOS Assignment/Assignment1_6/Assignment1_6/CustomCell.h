//
//  CustomCell.h
//  Assignment1_6
//
//  Created by Subhradeep  on 3/22/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface CustomCell : UITableViewCell

@property (strong, nonatomic) IBOutlet UIImageView *imageDisplay;
@property (strong, nonatomic) IBOutlet UILabel *idDisplay;
@property (strong, nonatomic) IBOutlet UILabel *nameDisplay;
@property (strong, nonatomic) IBOutlet UILabel *positionDisplay;
@property (strong, nonatomic) IBOutlet UILabel *genderDisplay;

@end
